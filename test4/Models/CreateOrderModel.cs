using System.ComponentModel.DataAnnotations;

namespace test4.Models
{
    public class CreateOrderModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string  ItemCode { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public int ItemQty { get; set; }
        [Required]
        public DateTime OrderDelivery { get; set; }
        [Required]
        public string OrderAddress { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}

