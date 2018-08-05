using System.ComponentModel.DataAnnotations;

namespace UniversalShopingApp.Models
{
    public class Email
    {
        [Required]
        [EmailAddress()]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
    }
}
