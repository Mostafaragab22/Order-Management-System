namespace OrderManagementSystem.DTO
{
    public class OrdWithCustDTO
    {
        public int CustomerId { set; get; }
        public string Name { set; get; }
        public List<OrdWithCustDTO> Order { set; get; }
    }
}
