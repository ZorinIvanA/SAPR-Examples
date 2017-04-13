using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DataBinding
{
    public class MaxValueValidationRule : ValidationRule
    {
        public Decimal MaxValue { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            decimal i = 0;
            try
            {
                i = Convert.ToDecimal(value);
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, "Это не число");
            }

            if (i <= MaxValue)
                return new ValidationResult(true, String.Empty);
            else
                return new ValidationResult(false, "Слишком большое число");
        }
    }
}
