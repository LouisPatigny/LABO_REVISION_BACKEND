namespace exo_revisions.API.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class CategoryCreateDTO
{
    public required string Name { get; set; }
}

public class CategoryUpdateDTO
{
    public required string Name { get; set; }
}