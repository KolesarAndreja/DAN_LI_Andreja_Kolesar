using System.Globalization;
using System.Windows.Controls;

namespace DAN_LI.Validation
{
    class ValidUsername : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string username = value as string;
            //check length
            if (Service.Service.UsedUsername(username))
            {
                return new ValidationResult(false, "This username is already taken");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
