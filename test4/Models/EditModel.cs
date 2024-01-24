using System.ComponentModel.DataAnnotations;

namespace test4.Models
{
    public class EditModel
    {
        [Required(ErrorMessage = "Please enter Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Delivery Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDelivery { get; set; }

        [Required(ErrorMessage = "Please enter Address")]
        public string OrderAddress { get; set; }
    }
}
