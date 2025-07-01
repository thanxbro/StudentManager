using StudentManager.DataBase.Data;
using System.Globalization;
using System.Windows.Data;

namespace StudentManager.Utils
{
    public class TeachersListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is List<Teacher> teachers)
            {
                return string.Join(", ", teachers.Select(t => t.Name));
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
