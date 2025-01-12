using exo_revisions.BLL.Models;
using Entities = exo_revisions.DAL.Entities;

namespace exo_revisions.BLL.Mappers;

public static class OrderItemMapper
{
    public static Entities.OrderItem ToEntity(this OrderItem orderItem)
    {
        return new Entities.OrderItem
        {
            Id = orderItem.Id,
            OrderId = orderItem.OrderId,
            ProductId = orderItem.ProductId,
            Quantity = orderItem.Quantity,
            UnitPrice = orderItem.UnitPrice,
            CreatedAt = orderItem.CreatedAt
        };
    }

    public static OrderItem ToModel(this Entities.OrderItem orderItem)
    {
        return new OrderItem
        {
            Id = orderItem.Id,
            OrderId = orderItem.OrderId,
            ProductId = orderItem.ProductId,
            Quantity = orderItem.Quantity,
            UnitPrice = orderItem.UnitPrice,
            CreatedAt = orderItem.CreatedAt
        };
    }
}