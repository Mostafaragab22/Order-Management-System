 namespace OrderManagementSystem.DTO
{
    public class OrderDTO
    {
        public int OrderId { set; get; }
        
        public DateOnly OrderDate { set; get; }
        public decimal TotalAmount { set; get; }
        public string PaymentMethod { set; get; }
        public string Status { set; get; }
        public List<OrderwithItems> items { set; get; }

    }
}
