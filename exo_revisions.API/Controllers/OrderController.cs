using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using exo_revisions.API.DTOs;
using exo_revisions.API.Mappers;
using exo_revisions.BLL.Interfaces;
using exo_revisions.BLL.Mappers;
using exo_revisions.BLL.Models;
using exo_revisions.DAL.Interfaces;

namespace exo_revisions.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderItemRepository _orderItemsRepository;
    private readonly IShippingAddressRepository _shippingAddressRepository;

    public OrderController(IOrderService orderService, IOrderRepository orderRepository, IOrderItemRepository orderItemsRepository, IShippingAddressRepository shippingAddressRepository)
    {
        _orderService = orderService;
        _orderRepository = orderRepository;
        _orderItemsRepository = orderItemsRepository;
        _shippingAddressRepository = shippingAddressRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrderDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetAll()
    {
        try
        {
            IEnumerable<OrderDTO> orders = _orderService.GetAll().Select(o => o.ToDTO());
            return Ok(orders);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetById(int id)
    {
        try
        {
            Order? order = _orderService.GetById(id);
            if (order == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }

            return Ok(order.ToDTO());
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("byEmail/{email}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetByEmail(string email)
    {
        try
        {
            Order? order = _orderService.GetByEmail(email);
            if (order == null)
            {
                return NotFound($"No order found for email {email}.");
            }
            return Ok(order.ToDTO());
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("allByEmail/{email}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrderDTO>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetAllByEmail(string email)
    {
        try
        {
            IEnumerable<OrderDTO> orders = _orderService.GetAllByEmail(email).Select(o => o.ToDTO());
            if (!orders.Any())
            {
                return NotFound($"No orders found for email {email}.");
            }
            return Ok(orders);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching orders.");
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OrderCreateDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Create([FromBody] OrderCreateDTO newOrder)
    {
        int newId = _orderService.Create(newOrder.ToModel());
        if (newId > 0)
        {
            return CreatedAtAction(nameof(GetById), new { id = newId }, newOrder);
        }

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpPost("checkout")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CheckoutPayloadDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Checkout([FromBody] CheckoutPayloadDTO payload)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            // 1. Create the shipping address
            var shippingAddress = new ShippingAddress
            {
                FirstName = payload.ShippingAddress.FirstName,
                LastName = payload.ShippingAddress.LastName,
                AddressLine1 = payload.ShippingAddress.AddressLine1,
                AddressLine2 = payload.ShippingAddress.AddressLine2,
                City = payload.ShippingAddress.City,
                PostalCode = payload.ShippingAddress.PostalCode,
                Country = payload.ShippingAddress.Country,
                PhoneNumber = payload.ShippingAddress.PhoneNumber
            };

            var shippingAddressId = _shippingAddressRepository.Create(shippingAddress.ToEntity());

            // 2. Create the Order
            var order = new Order
            {
                Email = payload.Email, // can also be taken from JWT if user is logged in
                OrderDate = payload.OrderDate,
                Status = payload.Status,
                TotalAmount = payload.TotalAmount,
                ShippingAddressId = shippingAddressId
            };

            var orderId = _orderRepository.Create(order.ToEntity());

            // 3. Create Order Items
            foreach (var cartItem in payload.CartItems)
            {
                var orderItem = new OrderItem
                {
                    OrderId = orderId,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.UnitPrice
                };
                _orderItemsRepository.Create(orderItem.ToEntity());
            }

            // 4. Return a response
            return Ok(new
            {
                OrderId = orderId,
                Message = "Order created successfully."
            });
        }
        catch (Exception ex)
        {
            // handle or log exceptions
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Update(int id, [FromBody] OrderUpdateDTO updatedOrder)
    {
        Order orderToUpdate = updatedOrder.ToModel();
        orderToUpdate.Id = id;

        if (_orderService.Update(orderToUpdate))
        {
            return Ok(orderToUpdate.ToDTO());
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Delete(int id)
    {
        try
        {
            return Ok(_orderService.Delete(id));
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}

