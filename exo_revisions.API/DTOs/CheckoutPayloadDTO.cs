using System.ComponentModel.DataAnnotations;

namespace exo_revisions.API.DTOs;

public class CheckoutPayloadDTO
{
    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; } = null!; // can be from token or provided
    public ShippingAddressDTO ShippingAddress { get; set; } = null!;
    public List<CartItemDTO> CartItems { get; set; } = new();
    public decimal DiscountApplied { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = "pending";
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
}

public class CartItemDTO
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}