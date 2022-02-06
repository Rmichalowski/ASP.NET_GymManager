using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GymManager.Infrastructure;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.Models
{
    public class Trainer : IValidatableObject
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Trainer Name")]
        [Required(ErrorMessage = "Trainer must have name!")]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [DisplayName("Trainer's Specialization")]
        public string Specialization { get; set; }

        [Display(Name = "Trainer's Phone")]
        public string Phone { get; set; }

        [Display(Name = "Email Address")]
        [CustomEmail]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        //walidacja wielopolowa
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) 
        {
            if (Phone == "" && Email == "")
            {
                yield return new ValidationResult(
                    $"It's 2022, come on you must have anything to communicate!",
                    new[] { "Phone", "Email" });
            }
        }
    }
}
