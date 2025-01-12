using exo_revisions.API.DTOs;
using Models = exo_revisions.BLL.Models;

namespace exo_revisions.API.Mappers;

public static class OrderMapper
{
    public static OrderDTO ToDTO(this Models.Order order)
    {
        return new OrderDTO()
        {
            Id = order.Id,
            Email = order.Email,
            OrderDate = order.OrderDate,
            Status = order.Status,
            TotalAmount = order.TotalAmount,
            ShippingAddressId = order.ShippingAddressId,
        };
    }

    public static Models.Order ToModel(this OrderDTO order)
    {
        return new Models.Order()
        {
            Id = order.Id,
            Email = order.Email,
            OrderDate = order.OrderDate,
            Status = order.Status,
            TotalAmount = order.TotalAmount,
            ShippingAddressId = order.ShippingAddressId,
        };
    }

    public static Models.Order ToModel(this OrderCreateDTO order)
    {
        return new Models.Order()
        {
            Id = order.Id,
            Email = order.Email,
            OrderDate = order.OrderDate,
            Status = order.Status,
            TotalAmount = order.TotalAmount,
            ShippingAddressId = order.ShippingAddressId,
        };
    }

    public static Models.Order ToModel(this OrderUpdateDTO order)
    {
        return new Models.Order()
        {
            Id = order.Id,
            Email = order.Email,
            OrderDate = order.OrderDate,
            Status = order.Status,
            TotalAmount = order.TotalAmount,
            ShippingAddressId = order.ShippingAddressId,
        };
    }
}