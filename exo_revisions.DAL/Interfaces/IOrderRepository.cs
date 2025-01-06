using exo_revisions.DAL.Entities;

namespace exo_revisions.DAL.Interfaces;

public interface IOrderRepository
{
    public IEnumerable<Order> GetAll();
    public Order? GetById(int id);
    public Order? GetByEmail(string email);
    public int Create(Order order);
    public bool Update(Order order);
    public bool Delete(int id);
}