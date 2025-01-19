using exo_revisions.BLL.Models;

namespace exo_revisions.BLL.Interfaces;

public interface IShippingAddressService
{
    public IEnumerable<ShippingAddress> GetAll();
    public ShippingAddress? GetById(int id);
    public int Create(ShippingAddress shippingAddress);
    public bool Update(ShippingAddress shippingAddress);
    public bool Delete(int id);
}