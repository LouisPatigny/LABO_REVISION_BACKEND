using exo_revisions.BLL.Models;
using Entities = exo_revisions.DAL.Entities;

namespace exo_revisions.BLL.Mappers;

public static class OrderMapper
{
    public static Entities.Order ToEntity(this Order order)
    {
        return new Entities.Order
        {
            Id = order.Id,
            Email = order.Email,
            OrderDate = order.OrderDate,
            Status = order.Status,
            TotalAmount = order.TotalAmount,
            DiscountApplied = order.DiscountApplied,
            ShippingAddressId = order.ShippingAddressId,
        };
    }

    public static Order ToModel(this Entities.Order order)
    {
        return new Order
        {
            Id = order.Id,
            Email = order.Email,
            OrderDate = order.OrderDate,
            Status = order.Status,
            TotalAmount = order.TotalAmount,
            DiscountApplied = order.DiscountApplied,
            ShippingAddressId = order.ShippingAddressId,
        };
    }
}