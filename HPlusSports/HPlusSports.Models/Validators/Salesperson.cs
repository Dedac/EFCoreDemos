using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HPlusSports.Models
{
    public partial class Salesperson : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Phone == null || Phone.Length < 10)
                yield return new ValidationResult("The phone number is too short", new[] { "Phone" });
            if (Email == null || Email.Length< 5)
                yield return new ValidationResult("The email is too short", new[] {"Email"});
        }
    }
}
