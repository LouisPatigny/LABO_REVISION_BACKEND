namespace exo_revisions.API.DTOs;

public class ProductDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
    public required string Status { get; set; }
    public int? CategoryId { get; set; }
}

public class ProductCreateDTO
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? ImageUrl { get; set; }
    public required string Status { get; set; }
    public int? CategoryId { get; set; }
}

public class ProductUpdateDTO
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? ImageUrl { get; set; }
    public required string Status { get; set; }
    public int? CategoryId { get; set; }
}