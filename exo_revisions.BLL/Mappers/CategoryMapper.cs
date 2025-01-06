using exo_revisions.BLL.Models;
using Entities = exo_revisions.DAL.Entities;

namespace exo_revisions.BLL.Mappers;

public static class CategoryMapper
{
    public static Entities.Category ToEntity(this Category category)
    {
        return new Entities.Category
        {
            Id = category.Id,
            Name = category.Name,
            CreatedAt = category.CreatedAt
        };
    }

    public static Category ToModel(this Entities.Category category)
    {
        return new Category
        {
            Id = category.Id,
            Name = category.Name,
            CreatedAt = category.CreatedAt
        };
    }
}