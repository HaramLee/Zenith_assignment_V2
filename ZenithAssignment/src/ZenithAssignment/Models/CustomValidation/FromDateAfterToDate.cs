using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithAssignment.Models.CustomValidation
{
    class FromDateAfterToDate : ValidationAttribute
    {
        DateTime _Before;
        DateTime _After;

        public FromDateAfterToDate() : base("From date is ahead of To date")
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Event e = (Event)validationContext.ObjectInstance;

            var day = new TimeSpan(1, 0, 0, 0);

            _After = e.ToDate;
            _Before = e.FromDate;

            
            if (_Before <= _After)
            {
                return ValidationResult.Success;
            }
            var errorMessage = FormatErrorMessage(validationContext.DisplayName);
            return new ValidationResult(errorMessage);
        }
    }
}
