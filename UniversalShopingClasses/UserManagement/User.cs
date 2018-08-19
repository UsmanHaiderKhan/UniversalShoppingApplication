using System;
using System.ComponentModel.DataAnnotations;

namespace UniversalShopingClasses.UserManagement
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"\\A[^\\W\\d_]+\\z", ErrorMessage = "Your Name did'nt consist of No...!")]
        public string Fullname { get; set; }
        [Required]
        public string Loginid { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Please Enter More The 6 Char")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*\W)\S{6,15}$", ErrorMessage = "Please Enter Capital small or special Char...! ")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Please Enter More The 6 Char")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "CNIC")]
        public long Cnic { get; set; }
        public DateTime DateofBirth { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public long MobileNo { get; set; }
        [Required]
        public string FullAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }

        public virtual Gender Gender { get; set; }
        public Role Role { get; set; }
        public bool IsInRole(int id)
        {
            return (Role != null && Role.Id == id);
        }
    }
}
