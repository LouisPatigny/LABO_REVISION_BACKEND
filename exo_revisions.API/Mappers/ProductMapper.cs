using exo_revisions.API.DTOs;
using Models = exo_revisions.BLL.Models;

namespace exo_revisions.API.Mappers;

public static class ProductMapper
{
    public static ProductDTO ToDTO(this Models.Product product)
    {
        return new ProductDTO()
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

    public static Models.Product ToModel(this ProductDTO product)
    {
        return new Models.Product()
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

    public static Models.Product ToModel(this ProductCreateDTO product)
    {
        return new Models.Product()
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            ImageUrl = product.ImageUrl,
            Status = product.Status,
            CategoryId = product.CategoryId
        };
    }

    public static Models.Product ToModel(this ProductUpdateDTO product)
    {
        return new Models.Product()
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            ImageUrl = product.ImageUrl,
            Status = product.Status,
            CategoryId = product.CategoryId
        };
    }
}