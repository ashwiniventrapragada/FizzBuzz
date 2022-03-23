using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz.Models
{
    public class FizzBuzzModel: IValidatableObject
    {
        [Required(ErrorMessage = "Input value is required")]
        [DisplayName("Please enter input values")]
        public string InputValues { get; set; }

        public IEnumerable<string> Result { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            if(string.IsNullOrEmpty(InputValues))
                yield return new ValidationResult("Input value is required");
        }
    }
}
