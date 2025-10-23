public class AccountsReceivable
{
    public Guid Id { get; set; }
    public Guid SalesOrderId { get; set; }
    public decimal AmountDue { get; set; }
    public decimal AmountReceived { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? PaymentDate { get; set; }
    public string Status { get; set; }
    public string Remarks { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    // Add this navigation property
    public SalesOrder SalesOrder { get; set; }
}