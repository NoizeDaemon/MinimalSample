using Avalonia.Controls;
using Avalonia;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Data.Converters;
using Avalonia.Data;

namespace MinimalSample
{
    public class StringToControlConverter : IMultiValueConverter
    {
        public static readonly StringToControlConverter Instance = new();

        public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
        {
            if (values[0] == AvaloniaProperty.UnsetValue || values[1] == AvaloniaProperty.UnsetValue || values[1] is null)
                return BindingOperations.DoNothing;
            else if ((string)values[1] == "")
                return AvaloniaProperty.UnsetValue;
            else
            {
                Control parent = (Control)values[0];
                string target = (string)values[1];

                Control control = parent.FindControl<Control>(target);

                return control ?? AvaloniaProperty.UnsetValue;
            }
        }
    }
}
