using OrderManagementSystem.Model;

namespace OrderManagementSystem.DTO
{
    public class InvoicewithOrderDTo
    {
        public int InvoiceIdId { get; set; }
        public int OrderId { get; set; }
        public DateOnly InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; } 
        public List<Order> OrderList { get; set; }
    }
}
