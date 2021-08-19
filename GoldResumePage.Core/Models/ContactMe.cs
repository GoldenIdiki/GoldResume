using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoldResumePage.Models
{
    public class ContactMe
    {
        [Key]
        public string ContactMeId { get; set; } = Guid.NewGuid().ToString();

        [Display(Name ="Full Name")]
        [Required]
        [RegularExpression(@"^[a-zA-Z\W_]+\s[a-zA-Z\W_]+(\s[a-zA-Z\W_]+)?$", ErrorMessage ="Please enter First Name and Last Name")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(\d{8,11})$", ErrorMessage ="Phone Number should be 8 - 11 digits long")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\d\W_]+\s[a-zA-Z\d\W_]+\s[a-zA-Z\d\W_]+\s[a-zA-Z\d\W_]+\s[a-zA-Z\d\s\W_]+(\s[a-zA-Z\d\s\W_]+)?", ErrorMessage ="Please enter atleast five words")]
        public string Message { get; set; }
    }
}
