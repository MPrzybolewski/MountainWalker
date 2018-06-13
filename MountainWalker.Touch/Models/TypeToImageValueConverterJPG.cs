using System;
using System.Globalization;
using MvvmCross.Platform.Converters;
using UIKit;

namespace MountainWalker.Touch.Models
{
    public class TypeToImageValueConverterJPG : IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string filename = (string)value + ".jpg";
            var test = UIImage.FromBundle("Images/" + filename);

            return test;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
