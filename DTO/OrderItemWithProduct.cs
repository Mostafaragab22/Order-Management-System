using OrderManagementSystem.Model;

namespace OrderManagementSystem.DTO
{
    public class OrderItemWithProduct
    {

        public int OrderItemId { get; set; }

        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }

        public List<Product> products { get; set; }
    }
}
