using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithAssignment.Models.CustomValidation
{
    class DateDifference : ValidationAttribute
    {
        DateTime _Before;
        DateTime _After;

        public DateDifference() : base ("Times are too far apart and they both must be on the same day.")
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Event e = (Event)validationContext.ObjectInstance;

            var day = new TimeSpan(1, 0, 0, 0);

            _After = e.ToDate;
            _Before = e.FromDate;


            if((_After - _Before) < day && _After.Day == _Before.Day)
            {
                return ValidationResult.Success;
            }
            var errorMessage = FormatErrorMessage(validationContext.DisplayName);
            return new ValidationResult(errorMessage);
        }
    }
}
