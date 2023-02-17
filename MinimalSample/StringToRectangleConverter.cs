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
            if (values[0] == AvaloniaProperty.UnsetValue || values[1] == AvaloniaProperty.UnsetValue || (string?)values[1] is null or "") return AvaloniaProperty.UnsetValue;
            else
            {
                

                Control parent = (Control)values[0];
                string target = (string)values[1];

                Rectangle rectangle = parent.FindControl<Rectangle>(target);

                return rectangle ?? AvaloniaProperty.UnsetValue;
            }
        }
    }
}
