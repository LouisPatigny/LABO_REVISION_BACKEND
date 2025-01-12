using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using exo_revisions.API.DTOs;
using exo_revisions.API.Mappers;
using exo_revisions.BLL.Interfaces;
using exo_revisions.BLL.Models;

namespace exo_revisions.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderItemController : ControllerBase
{
    private readonly IOrderItemService _orderItemService;

    public OrderItemController(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrderItemDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetAll()
    {
        try
        {
            IEnumerable<OrderItemDTO> items = _orderItemService.GetAll().Select(o => o.ToDTO());
            return Ok(items);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderItemDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetById(int id)
    {
        try
        {
            OrderItem? item = _orderItemService.GetById(id);
            if (item == null)
            {
                return NotFound($"OrderItem with ID {id} not found.");
            }
            return Ok(item.ToDTO());
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("order/{orderId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrderItemDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetByOrderId(int orderId)
    {
        try
        {
            IEnumerable<OrderItemDTO> items = _orderItemService.GetByOrderId(orderId).Select(o => o.ToDTO());
            return Ok(items);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("product/{productId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrderItemDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetByProductId(int productId)
    {
        try
        {
            IEnumerable<OrderItemDTO> items = _orderItemService.GetByProductId(productId).Select(o => o.ToDTO());
            return Ok(items);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OrderItemCreateDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Create([FromBody] OrderItemCreateDTO newOrderItem)
    {
        int newId = _orderItemService.Create(newOrderItem.ToModel());
        if (newId > 0)
        {
            return CreatedAtAction(nameof(GetById), new { id = newId }, newOrderItem);
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderItemDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Update(int id, [FromBody] OrderItemUpdateDTO updatedOrderItem)
    {
        OrderItem itemToUpdate = updatedOrderItem.ToModel();
        itemToUpdate.Id = id;

        if (_orderItemService.Update(itemToUpdate))
        {
            return Ok(itemToUpdate);
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
            return Ok(_orderItemService.Delete(id));
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
