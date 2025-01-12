using exo_revisions.API.DTOs;
using Models = exo_revisions.BLL.Models;

namespace exo_revisions.API.Mappers;

public static class OrderItemMapper
{
    public static OrderItemDTO ToDTO(this Models.OrderItem orderItem)
    {
        return new OrderItemDTO()
        {
            Id = orderItem.Id,
            OrderId = orderItem.OrderId,
            ProductId = orderItem.ProductId,
            Quantity = orderItem.Quantity,
            UnitPrice = orderItem.UnitPrice,
            CreatedAt = orderItem.CreatedAt
        };
    }

    public static Models.OrderItem ToModel(this OrderItemDTO orderItem)
    {
        return new Models.OrderItem()
        {
            Id = orderItem.Id,
            OrderId = orderItem.OrderId,
            ProductId = orderItem.ProductId,
            Quantity = orderItem.Quantity,
            UnitPrice = orderItem.UnitPrice,
            CreatedAt = orderItem.CreatedAt
        };
    }

    public static Models.OrderItem ToModel(this OrderItemCreateDTO orderItem)
    {
        return new Models.OrderItem()
        {
            OrderId = orderItem.OrderId,
            ProductId = orderItem.ProductId,
            Quantity = orderItem.Quantity,
            UnitPrice = orderItem.UnitPrice,
        };
    }

    public static Models.OrderItem ToModel(this OrderItemUpdateDTO orderItem)
    {
        return new Models.OrderItem()
        {
            Quantity = orderItem.Quantity,
            UnitPrice = orderItem.UnitPrice,
        };
    }
}