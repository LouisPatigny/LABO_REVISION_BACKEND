using exo_revisions.API.DTOs;
using Models = exo_revisions.BLL.Models;

namespace exo_revisions.API.Mappers;

public static class UserMapper
{
    public static UserDTO ToDTO(this Models.User user)
    {
        return new UserDTO()
        {
          Id = user.Id,
          Email = user.Email,
          CreatedAt = user.CreatedAt,
          FidelityPoints = user.FidelityPoints
        };
    }

    public static Models.User ToModel(this UserCreateDTO user)
    {
        return new Models.User()
        {
            Email = user.Email,
            Password = user.Password
        };
    }
}