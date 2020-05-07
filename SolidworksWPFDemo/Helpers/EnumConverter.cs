using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace SolidworksWPFDemo.Helpers
{
    public static class EnumExtentions
    {
        public static string ToDescription(this Enum e)
        {
            var attributes = (DisplayAttribute[])e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DisplayAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }

        public static string ToName(this Enum e)
        {
            var attributes = (DisplayAttribute[])e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DisplayAttribute), false);
            return attributes.Length > 0 ? attributes[0].Name : null;
        }
    }
}
