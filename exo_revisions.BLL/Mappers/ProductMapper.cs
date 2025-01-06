using exo_revisions.BLL.Models;
using Entities = exo_revisions.DAL.Entities;

namespace exo_revisions.BLL.Mappers;

public static class ProductMapper
{
    public static Entities.Product ToEntity(this Product product)
    {
        return new Entities.Product
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            ImageUrl = product.ImageUrl,
            CreatedAt = product.CreatedAt,
            DeletedAt = product.DeletedAt,
            Status = product.Status,
            CategoryId = product.CategoryId
        };
    }

    public static Product ToModel(this Entities.Product product)
    {
        return new Product
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            ImageUrl = product.ImageUrl,
            CreatedAt = product.CreatedAt,
            DeletedAt = product.DeletedAt,
            Status = product.Status,
            CategoryId = product.CategoryId
        };
    }
}