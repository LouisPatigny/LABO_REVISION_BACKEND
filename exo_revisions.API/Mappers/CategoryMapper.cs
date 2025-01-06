using exo_revisions.API.DTOs;
using Models = exo_revisions.BLL.Models;

namespace exo_revisions.API.Mappers;

public static class CategoryMapper
{
    public static CategoryDTO ToDTO(this Models.Category category)
    {
        return new CategoryDTO()
        {
            Id = category.Id,
            Name = category.Name,
            CreatedAt = category.CreatedAt
        };
    }

    public static Models.Category ToModel(this CategoryDTO category)
    {
        return new Models.Category()
        {
            Id = category.Id,
            Name = category.Name,
            CreatedAt = category.CreatedAt
        };
    }

    public static Models.Category ToModel(this CategoryCreateDTO category)
    {
        return new Models.Category()
        {
            Name = category.Name
        };
    }

    public static Models.Category ToModel(this CategoryUpdateDTO category)
    {
        return new Models.Category()
        {
            Name = category.Name
        };
    }
}