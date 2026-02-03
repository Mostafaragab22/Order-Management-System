using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementSystem.Model
{
    public class Order
    {
        public int OrderId { set; get; }
        [ForeignKey("Customer")]
        public int CustomerId { set; get; }
        
        public DateOnly OrderDate { set; get; }
        public decimal TotalAmount { set; get; }
        public string OrderItem { set; get; }
        public string PaymentMethod {  set; get; }
        public string Status { set; get; }

        
    }
}
