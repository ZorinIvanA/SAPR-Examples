using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media;

namespace DataBinding
{
    public class MetroStationColorConverter : IValueConverter
    {
        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            try
            {
                var stationName = value as String;
                if (String.IsNullOrWhiteSpace(stationName))
                    return Colors.White;

                switch (stationName)
                {
                    case "Профсоюзная":
                    case "Академическая":
                    case "Октябрьская":
                    case "Шаболовская":
                        {
                            return new SolidColorBrush(Colors.Orange);
                        }
                    case "Нахимовский проспект":
                    case "Севастопольская":
                        {
                            return new SolidColorBrush(Colors.LightGray);
                        }
                    case "Коломенская":
                        {
                            return new SolidColorBrush(Colors.DarkGreen);
                        }
                    default:
                        {
                            return new SolidColorBrush(Colors.White);
                        }
                }
            }
            catch
            {
                return Colors.White;
            }
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

