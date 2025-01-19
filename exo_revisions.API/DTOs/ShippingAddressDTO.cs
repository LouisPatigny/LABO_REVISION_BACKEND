namespace exo_revisions.API.DTOs;

public class ShippingAddressDTO
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }
    public required string Country { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class ShippingAddressCreateDTO
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }
    public required string Country { get; set; }
    public string? PhoneNumber { get; set; }
}

public class ShippingAddressUpdateDTO
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }
    public required string Country { get; set; }
    public string? PhoneNumber { get; set; }
}