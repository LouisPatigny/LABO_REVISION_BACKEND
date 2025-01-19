namespace exo_revisions.BLL.Models;

public class Order
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public DateTime OrderDate { get; set; }
    public required string Status { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal DiscountApplied { get; set; }
    public int? ShippingAddressId { get; set; }
}