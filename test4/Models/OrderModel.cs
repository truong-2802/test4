using System.ComponentModel.DataAnnotations;

namespace test4.Models
{
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime DeliveryTime { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ContactPhone { get; set; }
    }
}

