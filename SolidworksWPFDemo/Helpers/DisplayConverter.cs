using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using SolidworksWPFDemo.Library;

namespace SolidworksWPFDemo.Helpers
{
    public class DisplayConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((ILibrary)value).DisplayName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
