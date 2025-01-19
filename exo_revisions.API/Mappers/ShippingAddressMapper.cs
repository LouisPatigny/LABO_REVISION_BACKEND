using exo_revisions.API.DTOs;
using Models = exo_revisions.BLL.Models;

namespace exo_revisions.API.Mappers;

public static class ShippingAddressMapper
{
    public static ShippingAddressDTO ToDTO(this Models.ShippingAddress shippingAddress)
    {
        return new ShippingAddressDTO()
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

    public static Models.ShippingAddress ToModel(this ShippingAddressDTO shippingAddress)
    {
        return new Models.ShippingAddress()
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
        };
    }

    public static Models.ShippingAddress ToModel(this ShippingAddressCreateDTO shippingAddress)
    {
        return new Models.ShippingAddress()
        {
            FirstName = shippingAddress.FirstName,
            LastName = shippingAddress.LastName,
            AddressLine1 = shippingAddress.AddressLine1,
            AddressLine2 = shippingAddress.AddressLine2,
            City = shippingAddress.City,
            PostalCode = shippingAddress.PostalCode,
            Country = shippingAddress.Country,
            PhoneNumber = shippingAddress.PhoneNumber,
        };
    }

    public static Models.ShippingAddress ToModel(this ShippingAddressUpdateDTO shippingAddress)
    {
        return new Models.ShippingAddress()
        {
            FirstName = shippingAddress.FirstName,
            LastName = shippingAddress.LastName,
            AddressLine1 = shippingAddress.AddressLine1,
            AddressLine2 = shippingAddress.AddressLine2,
            City = shippingAddress.City,
            PostalCode = shippingAddress.PostalCode,
            Country = shippingAddress.Country,
            PhoneNumber = shippingAddress.PhoneNumber,
        };
    }
}