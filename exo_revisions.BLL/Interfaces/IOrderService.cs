using exo_revisions.BLL.Models;

namespace exo_revisions.BLL.Interfaces;

public interface IOrderService
{
    public IEnumerable<Order> GetAll();
    public Order? GetById(int id);
    public Order? GetByEmail(string email);
    IEnumerable<Order> GetAllByEmail(string email);
    public int Create(Order order);
    public bool Update(Order order);
    public bool Delete(int id);
}