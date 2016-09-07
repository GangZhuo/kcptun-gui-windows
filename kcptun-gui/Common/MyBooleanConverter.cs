using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace kcptun_gui.Common
{
    public class MyBooleanConverter : BooleanConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (string.Equals((string)value, "True", StringComparison.InvariantCultureIgnoreCase) ||
                string.Equals((string)value, "Yes", StringComparison.InvariantCultureIgnoreCase))
                return true;
            return false;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
        {
            return destType == typeof(string);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture,
                                         object value, Type destType)
        {
            if ((bool)value)
                return I18N.GetString("Yes");
            else
                return I18N.GetString("No");
        }

    }
}
