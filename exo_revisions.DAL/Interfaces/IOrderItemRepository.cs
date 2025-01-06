using exo_revisions.DAL.Entities;

namespace exo_revisions.DAL.Interfaces;

public interface IOrderItemRepository
{
    public IEnumerable<OrderItem> GetAll();
    public OrderItem? GetById(int id);
    IEnumerable<OrderItem> GetByOrderId(int orderId);
    IEnumerable<OrderItem> GetByProductId(int productId);
    public int Create(OrderItem orderItem);
    public bool Update(OrderItem orderItem);
    public bool Delete(int id);
}