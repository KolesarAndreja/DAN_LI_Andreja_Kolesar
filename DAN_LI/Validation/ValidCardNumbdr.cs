using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DAN_LI.Validation
{
    class ValidCardNumbdr:ValidationRule

    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string account = value as string;

            if (Service.Service.UsedCardNumber(account))
            {
                return new ValidationResult(false, "This insurance card number is already taken");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
