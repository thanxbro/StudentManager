using StudentManager.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace StudentManager.Utils
{
    public class EnumToRussianConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                Gender.Male => "Мужской",
                Gender.Female => "Женский"
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                "Мужской" => Gender.Male,
                "Женский" => Gender.Female
            };
        }
    }
    public static class GenderEnumHelper
    {
        public static Array Values => Enum.GetValues(typeof(Gender));

    }
}
