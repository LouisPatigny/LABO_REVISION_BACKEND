namespace exo_revisions.API.DTOs;

public class OrderDTO
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public DateTime OrderDate { get; set; }
    public required string Status { get; set; }
    public decimal TotalAmount { get; set; }
    public int? ShippingAddressId { get; set; }
}

public class OrderCreateDTO
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public DateTime OrderDate { get; set; }
    public required string Status { get; set; }
    public decimal TotalAmount { get; set; }
    public int? ShippingAddressId { get; set; }
}

public class OrderUpdateDTO
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public DateTime OrderDate { get; set; }
    public required string Status { get; set; }
    public decimal TotalAmount { get; set; }
    public int? ShippingAddressId { get; set; }
}