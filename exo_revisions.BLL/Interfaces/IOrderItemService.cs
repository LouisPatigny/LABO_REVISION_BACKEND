using exo_revisions.BLL.Models;

namespace exo_revisions.BLL.Interfaces;

public interface IOrderItemService
{
    public IEnumerable<OrderItem> GetAll();
    public OrderItem? GetById(int id);
    IEnumerable<OrderItem> GetByOrderId(int orderId);
    IEnumerable<OrderItem> GetByProductId(int productId);
    public int Create(OrderItem orderItem);
    public bool Update(OrderItem orderItem);
    public bool Delete(int id);
}