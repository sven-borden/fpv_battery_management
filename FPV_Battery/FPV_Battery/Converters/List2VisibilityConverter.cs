using FPV_Battery.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace FPV_Battery.Converters
{
    public class List2VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter.ToString() == "emptypart")
            {
                if ((value as ObservableCollection<Battery>).Count == 0)
                    return true;
                else
                    return false;
            }
            if (parameter.ToString() == "listpart")
            {
                if ((value as ObservableCollection<Battery>).Count == 0)
                    return false;
                else
                    return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

