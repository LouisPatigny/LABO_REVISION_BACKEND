using exo_revisions.BLL.Interfaces;
using exo_revisions.BLL.Mappers;
using exo_revisions.BLL.Models;
using exo_revisions.DAL.Interfaces;

namespace exo_revisions.BLL.Services;

public class ShippingAddressService : IShippingAddressService
{
    private readonly IShippingAddressRepository _shippingAddressRepository;

    public ShippingAddressService(IShippingAddressRepository shippingAddressRepository)
    {
        _shippingAddressRepository = shippingAddressRepository;
    }

    public IEnumerable<ShippingAddress> GetAll()
    {
        return _shippingAddressRepository.GetAll().Select(sa => sa.ToModel());
    }

    public ShippingAddress? GetById(int id)
    {
        return _shippingAddressRepository.GetById(id)?.ToModel();
    }

    public int Create(ShippingAddress shippingAddress)
    {
        return _shippingAddressRepository.Create(shippingAddress.ToEntity());
    }

    public bool Update(ShippingAddress shippingAddress)
    {
        return _shippingAddressRepository.Update(shippingAddress.ToEntity());
    }

    public bool Delete(int id)
    {
        return _shippingAddressRepository.Delete(id);
    }
}