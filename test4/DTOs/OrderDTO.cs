namespace test4.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; } 
        public string ItemName { get; set; }
        public int Quantity { get; set;}
        public DateTime DeliveryTime { get; set; }
        public string Address { get; set; }
        public string ContactPhone { get; set; }
    }
}
