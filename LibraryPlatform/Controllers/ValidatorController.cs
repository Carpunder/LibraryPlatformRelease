using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlatform.Controllers
{
    public static class ValidatorController
    {
        public static bool TryValidate(object obj, out string errorMessage)
        {
            var text = "";
            var validationContext = new ValidationContext(obj);
            var validationResult = new List<ValidationResult>();
            if (!Validator.TryValidateObject(obj, validationContext, validationResult, true))
            {
                foreach (var error in validationResult)
                {
                    text += error.ErrorMessage;
                    text += Environment.NewLine;
                }
                errorMessage = text;
                return false;
            }
            else
            {
                errorMessage = null;
                return true;
            }
        }
    }
}
