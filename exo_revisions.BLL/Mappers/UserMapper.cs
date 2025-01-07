using exo_revisions.BLL.Models;
using Entities = exo_revisions.DAL.Entities;

namespace exo_revisions.BLL.Mappers;

public static class UserMapper
{
    public static Entities.User ToEntity(this User user)
    {
        return new Entities.User
        {
            Id = user.Id,
            Email = user.Email,
            Password = user.Password,
            CreatedAt = user.CreatedAt,
            FidelityPoints = user.FidelityPoints
        };
    }

    public static User ToModel(this Entities.User user)
    {
        return new User
        {
            Id = user.Id,
            Email = user.Email,
            Password = user.Password,
            CreatedAt = user.CreatedAt,
            FidelityPoints = user.FidelityPoints
        };
    }
}