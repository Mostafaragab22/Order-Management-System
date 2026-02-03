namespace OrderManagementSystem.Model
{
    public class Invoice
    {
        public int InvoiceId{ get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public DateOnly InvoiceDate { get; set; }
        public decimal TotalAmount {  get; set; }


    }
}
