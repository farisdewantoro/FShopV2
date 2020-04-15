using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace FShopV2.Base.ValidatorAttribute
{
    public class ValidGuidAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "'{0}' is required";

        public ValidGuidAttribute() : base(DefaultErrorMessage)
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            HashSet<string> memberNames = new HashSet<string>();
            memberNames.Add(validationContext.MemberName);

            var input = Convert.ToString(value, CultureInfo.CurrentCulture);

            // let the Required attribute take care of this validation
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }
            

            Guid guid;
            if (!Guid.TryParse(input, out guid))
            {
                // not a validstring representation of a guid
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName), memberNames);
            }
            if (Guid.Empty == guid)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName), memberNames);
            }
            return null;
        }
    }
}
