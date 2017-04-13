using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DataBinding
{
    public class FlatCostClassConverter : IMultiValueConverter
    {
        private const decimal CHEAP_COST = 70000;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var cost = (decimal)values[0];
            var area = (UInt32)values[1];

            var meterCost = cost / area;
            if (meterCost >= CHEAP_COST)
                return "Дорогая";
            else
                return "Дешёвая";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
