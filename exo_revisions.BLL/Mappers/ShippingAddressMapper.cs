using exo_revisions.BLL.Models;
using Entities = exo_revisions.DAL.Entities;


namespace exo_revisions.BLL.Mappers;

public static class ShippingAddressMapper
{
    public static Entities.ShippingAddress ToEntity(this ShippingAddress shippingAddress)
    {
        return new Entities.ShippingAddress
        {
            Id = shippingAddress.Id,
            FirstName = shippingAddress.FirstName,
            LastName = shippingAddress.LastName,
            AddressLine1 = shippingAddress.AddressLine1,
            AddressLine2 = shippingAddress.AddressLine2,
            City = shippingAddress.City,
            PostalCode = shippingAddress.PostalCode,
            Country = shippingAddress.Country,
            PhoneNumber = shippingAddress.PhoneNumber,
            CreatedAt = shippingAddress.CreatedAt
        };
    }

    public static ShippingAddress ToModel(this Entities.ShippingAddress shippingAddress)
    {
        return new ShippingAddress
        {
            Id = shippingAddress.Id,
            FirstName = shippingAddress.FirstName,
            LastName = shippingAddress.LastName,
            AddressLine1 = shippingAddress.AddressLine1,
            AddressLine2 = shippingAddress.AddressLine2,
            City = shippingAddress.City,
            PostalCode = shippingAddress.PostalCode,
            Country = shippingAddress.Country,
            PhoneNumber = shippingAddress.PhoneNumber,
            CreatedAt = shippingAddress.CreatedAt
        };
    }
}