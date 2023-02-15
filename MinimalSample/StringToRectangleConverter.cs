using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Data;
using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalSample
{
    public class StringToRectangleConverter : IMultiValueConverter
    {
        public static readonly StringToRectangleConverter Instance = new();

        public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
        {
            Control parent = (Control)values[0];
            string target = (string)values[1];

            if (target == "") return AvaloniaProperty.UnsetValue;
            else return parent.FindControl<Rectangle>(target);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
