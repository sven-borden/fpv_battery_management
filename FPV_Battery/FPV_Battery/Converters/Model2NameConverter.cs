using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FPV_Battery.Converters
{
    public class Model2NameConverter : IValueConverter
    {
        private Dictionary<string, string> ModelName = new Dictionary<string, string>()
        {
            {"6928493384565", "Tattu Fun Fly" },
            {"6928493358467", "Tattu R-Line V1.0" }
        };

        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "Unkown Model";
            string m = (string)value;
            m = string.Concat(m.Where(c => !char.IsWhiteSpace(c)));
            if (ModelName.ContainsKey(m))
                return ModelName[m];
            else
                return "Unknown Model";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
