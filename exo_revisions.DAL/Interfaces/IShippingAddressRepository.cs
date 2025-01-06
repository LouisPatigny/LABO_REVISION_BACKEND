using exo_revisions.DAL.Entities;

namespace exo_revisions.DAL.Interfaces;

public interface IShippingAddressRepository
{
    public IEnumerable<ShippingAddress> GetAll();
    public ShippingAddress? GetById(int id);
    public int Create(ShippingAddress shippingAddress);
    public bool Update(ShippingAddress shippingAddress);
    public bool Delete(int id);
}