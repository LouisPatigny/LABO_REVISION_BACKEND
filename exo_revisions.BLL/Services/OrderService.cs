using exo_revisions.BLL.Interfaces;
using exo_revisions.BLL.Mappers;
using exo_revisions.BLL.Models;
using exo_revisions.DAL.Interfaces;

namespace exo_revisions.BLL.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public IEnumerable<Order> GetAll()
    {
        return _orderRepository.GetAll().Select(o => o.ToModel());
    }

    public Order? GetById(int id)
    {
        return _orderRepository.GetById(id)?.ToModel();
    }

    public Order? GetByEmail(string email)
    {
        return _orderRepository.GetByEmail(email)?.ToModel();
    }

    public IEnumerable<Order> GetAllByEmail(string email)
    {
        return _orderRepository.GetAllByEmail(email).Select(o => o.ToModel());
    }

    public int Create(Order order)
    {
        return _orderRepository.Create(order.ToEntity());
    }

    public bool Update(Order order)
    {
        return _orderRepository.Update(order.ToEntity());
    }

    public bool Delete(int id)
    {
        return _orderRepository.Delete(id);
    }
}