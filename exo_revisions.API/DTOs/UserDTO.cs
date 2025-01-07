namespace exo_revisions.API.DTOs;

public class UserDTO
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public int FidelityPoints { get; set; }
}

public class UserCreateDTO
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}

public class UserLoginDTO
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}