using System.ComponentModel.DataAnnotations;
using System;
namespace GymManager.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter the name.")]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your Age!")]
        [Range(4,200, ErrorMessage = "People in range 4-200 yrs old allowed.")]
        public int Age { get; set; }

        [RegularExpression(@"^[0-9]{9,9}$", ErrorMessage = "Input valid phone number!")]
        public string Phone { get; set; }   

        public virtual Trainer Trainer { get; set; }
    }
}
