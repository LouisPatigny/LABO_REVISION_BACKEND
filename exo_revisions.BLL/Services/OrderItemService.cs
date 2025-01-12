using exo_revisions.BLL.Interfaces;
using exo_revisions.BLL.Mappers;
using exo_revisions.BLL.Models;
using exo_revisions.DAL.Interfaces;

namespace exo_revisions.BLL.Services;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IProductRepository _productRepository;

    public OrderItemService(IOrderItemRepository orderItemRepository, IProductRepository productRepository)
    {
        _orderItemRepository = orderItemRepository;
        _productRepository = productRepository;
    }

    public IEnumerable<OrderItem> GetAll()
    {
        return _orderItemRepository.GetAll().Select(o => o.ToModel());
    }

    public OrderItem? GetById(int id)
    {
        return _orderItemRepository.GetById(id)?.ToModel();
    }

    public IEnumerable<OrderItem> GetByOrderId(int orderId)
    {
        return _orderItemRepository.GetByOrderId(orderId).Select(o => o.ToModel());
    }

    public IEnumerable<OrderItem> GetByProductId(int productId)
    {
        return _orderItemRepository.GetByProductId(productId).Select(o => o.ToModel());
    }

    public int Create(OrderItem orderItem)
    {
        // 1) Check stock
        var product = _productRepository.GetById(orderItem.ProductId);
        if (product is null || product.Stock < orderItem.Quantity)
        {
            throw new Exception("Not enough stock");
        }

        // 2) Insert order item
        int newId = _orderItemRepository.Create(orderItem.ToEntity());

        // 3) Decrement stock
        product.Stock -= orderItem.Quantity;
        _productRepository.Update(product);

        // 4) Return new ID
        return newId;
    }

    public bool Update(OrderItem orderItem)
    {
        return _orderItemRepository.Update(orderItem.ToEntity());
    }

    public bool Delete(int id)
    {
        return _orderItemRepository.Delete(id);
    }
}