using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalSample
{
    public class EasyAlignWith : RelativePanel
    {
        static EasyAlignWith()
        {
            AffectsParentArrange<RelativePanel>(EasyRightOfProperty, EasyLeftOfProperty, EasyAboveProperty, EasyBelowProperty);
        }

        //////////////////////////
        /// EasyAlignDirection ///
        //////////////////////////
      
        //[ResolveByName]
        //public static string GetEasyAlignDirection(AvaloniaObject obj)
        //{
        //    return (string)obj.GetValue(EasyAlignDirectionProperty);
        //}

        //public static void SetEasyRightOf(AvaloniaObject obj, string value)
        //{
        //    obj.SetValue(EasyAlignDirectionProperty, value);
        //}

        //public static readonly AttachedProperty<string> EasyAlignDirectionProperty =
        //    AvaloniaProperty.RegisterAttached<RelativePanel, Layoutable, string>("EasyAlignDirection");


        /////////////////////
        /// EasyAlignWith ///
        /////////////////////


        /////////////
        /// RIGHT ///
        /////////////

        /// <summary>
        /// Gets the value of the RelativePanel.EasyRightOf XAML attached property for the target element.
        /// </summary>
        /// <param name="obj">The object from which the property value is read.</param>
        /// <returns>
        /// The RelativePanel.EasyRightOf XAML attached property value of the specified
        /// object.
        /// </returns>        
        [ResolveByName]
        public static object GetEasyRightOf(AvaloniaObject obj)
        {
            return (object)obj.GetValue(EasyRightOfProperty);
        }

        /// <summary>
        /// Sets the value of the RelativePanel.EasyRightOf XAML attached property for a target element.
        /// </summary>
        /// <param name="obj">The object to which the property value is written.</param>
        /// <param name="value">The value to set. (The element to easy-align this element with.)</param>
        [ResolveByName]
        public static void SetEasyRightOf(AvaloniaObject obj, object value)
        {
            if (value != AvaloniaProperty.UnsetValue)
            {
                if (obj.GetValue(LeftOfProperty) == value) obj.SetValue(LeftOfProperty, AvaloniaProperty.UnsetValue);
                if (obj.GetValue(AboveProperty) == value) obj.SetValue(AboveProperty, AvaloniaProperty.UnsetValue);
                if (obj.GetValue(BelowProperty) == value) obj.SetValue(BelowProperty, AvaloniaProperty.UnsetValue);
                if (obj.GetValue(AlignHorizontalCenterWithProperty) == value) obj.SetValue(AlignHorizontalCenterWithProperty, AvaloniaProperty.UnsetValue);
                if (obj.GetValue(EasyLeftOfProperty) == value) SetEasyLeftOf(obj, AvaloniaProperty.UnsetValue);
                if (obj.GetValue(EasyAboveProperty) == value) SetEasyAbove(obj, AvaloniaProperty.UnsetValue);
                if (obj.GetValue(EasyBelowProperty) == value) SetEasyBelow(obj, AvaloniaProperty.UnsetValue);
            }

            obj.SetValue(AlignVerticalCenterWithProperty, value);
            obj.SetValue(RightOfProperty,value);

            obj.SetValue(EasyRightOfProperty, value);
        }

        /// <summary>
        ///  Identifies the <see cref="RelativePanel.EasyAlignWithProperty"/> XAML attached property.
        /// </summary>

        public static readonly AttachedProperty<object> EasyRightOfProperty =
            AvaloniaProperty.RegisterAttached<RelativePanel, Layoutable, object>("EasyRightOf");


        ////////////
        /// LEFT ///
        ////////////

        /// <summary>
        /// Gets the value of the RelativePanel.EasyLeftOf XAML attached property for the target element.
        /// </summary>
        /// <param name="obj">The object from which the property value is read.</param>
        /// <returns>
        /// The RelativePanel.EasyLeftOf XAML attached property value of the specified
        /// object.
        /// </returns>        
        [ResolveByName]
        public static object GetEasyLeftOf(AvaloniaObject obj)
        {
            return (object)obj.GetValue(EasyLeftOfProperty);
        }

        /// <summary>
        /// Sets the value of the RelativePanel.EasyLeftOf XAML attached property for a target element.
        /// </summary>
        /// <param name="obj">The object to which the property value is written.</param>
        /// <param name="value">The value to set. (The element to easy-align this element with.)</param>
        [ResolveByName]
        public static void SetEasyLeftOf(AvaloniaObject obj, object value)
        {
            if (value != AvaloniaProperty.UnsetValue)
            {
                if (obj.GetValue(RightOfProperty) == value) obj.SetValue(RightOfProperty, AvaloniaProperty.UnsetValue);
                if (obj.GetValue(AboveProperty) == value) obj.SetValue(AboveProperty, AvaloniaProperty.UnsetValue);
                if (obj.GetValue(BelowProperty) == value) obj.SetValue(BelowProperty, AvaloniaProperty.UnsetValue);
                if (obj.GetValue(AlignHorizontalCenterWithProperty) == value) obj.SetValue(AlignHorizontalCenterWithProperty, AvaloniaProperty.UnsetValue);
                if (obj.GetValue(EasyRightOfProperty) == value) SetEasyRightOf(obj, AvaloniaProperty.UnsetValue);
                if (obj.GetValue(EasyAboveProperty) == value) SetEasyAbove(obj, AvaloniaProperty.UnsetValue);
                if (obj.GetValue(EasyBelowProperty) == value) SetEasyBelow(obj, AvaloniaProperty.UnsetValue);
            }

            obj.SetValue(AlignVerticalCenterWithProperty, value);
            obj.SetValue(LeftOfProperty, value);

            obj.SetValue(EasyLeftOfProperty, value);
        }

        /// <summary>
        ///  Identifies the <see cref="RelativePanel.EasyAlignWithProperty"/> XAML attached property.
        /// </summary>

        public static readonly AttachedProperty<object> EasyLeftOfProperty =
            AvaloniaProperty.RegisterAttached<RelativePanel, Layoutable, object>("EasyLeftOf");


        /////////////
        /// Above ///
        /////////////

        /// <summary>
        /// Gets the value of the RelativePanel.EasyAbove XAML attached property for the target element.
        /// </summary>
        /// <param name="obj">The object from which the property value is read.</param>
        /// <returns>
        /// The RelativePanel.EasyAbove XAML attached property value of the specified
        /// object.
        /// </returns>        
        [ResolveByName]
        public static object GetEasyAbove(AvaloniaObject obj)
        {
            return (object)obj.GetValue(EasyAboveProperty);
        }

        /// <summary>
        /// Sets the value of the RelativePanel.EasyAbove XAML attached property for a target element.
        /// </summary>
        /// <param name="obj">The object to which the property value is written.</param>
        /// <param name="value">The value to set. (The element to easy-align this element with.)</param>
        [ResolveByName]
        public static void SetEasyAbove(AvaloniaObject obj, object value)
        {
            if (value != AvaloniaProperty.UnsetValue)
            {
                if (obj.GetValue(RightOfProperty) == value) obj.SetValue(RightOfProperty, AvaloniaProperty.UnsetValue);
                if (obj.GetValue(LeftOfProperty) == value) obj.SetValue(LeftOfProperty, AvaloniaProperty.UnsetValue);
                if (obj.GetValue(BelowProperty) == value) obj.SetValue(BelowProperty, AvaloniaProperty.UnsetValue);
                if (obj.GetValue(AlignVerticalCenterWithProperty) == value) obj.SetValue(AlignVerticalCenterWithProperty, AvaloniaProperty.UnsetValue);
                if (obj.GetValue(EasyRightOfProperty) == value) SetEasyRightOf(obj, AvaloniaProperty.UnsetValue);
                if (obj.GetValue(EasyLeftOfProperty) == value) SetEasyLeftOf(obj, AvaloniaProperty.UnsetValue);
                if (obj.GetValue(EasyBelowProperty) == value) SetEasyBelow(obj, AvaloniaProperty.UnsetValue);
            }


            obj.SetValue(AlignHorizontalCenterWithProperty, value);
            obj.SetValue(AboveProperty, value);

            obj.SetValue(EasyAboveProperty, value);
        }

        /// <summary>
        ///  Identifies the <see cref="RelativePanel.EasyAlignWithProperty"/> XAML attached property.
        /// </summary>

        public static readonly AttachedProperty<object> EasyAboveProperty =
            AvaloniaProperty.RegisterAttached<RelativePanel, Layoutable, object>("EasyAbove");


        /////////////
        /// Below ///
        /////////////

        /// <summary>
        /// Gets the value of the RelativePanel.EasyBelow XAML attached property for the target element.
        /// </summary>
        /// <param name="obj">The object from which the property value is read.</param>
        /// <returns>
        /// The RelativePanel.EasyBelow XAML attached property value of the specified
        /// object.
        /// </returns>        
        [ResolveByName]
        public static object GetEasyBelow(AvaloniaObject obj)
        {
            return (object)obj.GetValue(EasyBelowProperty);
        }

        /// <summary>
        /// Sets the value of the RelativePanel.EasyBelow XAML attached property for a target element.
        /// </summary>
        /// <param name="obj">The object to which the property value is written.</param>
        /// <param name="value">The value to set. (The element to easy-align this element with.)</param>
        [ResolveByName]
        public static void SetEasyBelow(AvaloniaObject obj, object value)
        {
            if (value != AvaloniaProperty.UnsetValue)
            {
                if (obj.GetValue(RightOfProperty) == value) obj.SetValue(RightOfProperty, AvaloniaProperty.UnsetValue);
                if (obj.GetValue(LeftOfProperty) == value) obj.SetValue(LeftOfProperty, AvaloniaProperty.UnsetValue);
                if (obj.GetValue(BelowProperty) == value) obj.SetValue(BelowProperty, AvaloniaProperty.UnsetValue);
                if (obj.GetValue(AlignVerticalCenterWithProperty) == value) obj.SetValue(AlignVerticalCenterWithProperty, AvaloniaProperty.UnsetValue);
                if (obj.GetValue(EasyRightOfProperty) == value) SetEasyRightOf(obj, AvaloniaProperty.UnsetValue);
                if (obj.GetValue(EasyLeftOfProperty) == value) SetEasyLeftOf(obj, AvaloniaProperty.UnsetValue);
                if (obj.GetValue(EasyAboveProperty) == value) SetEasyAbove(obj, AvaloniaProperty.UnsetValue);
            }

            obj.SetValue(AlignHorizontalCenterWithProperty, value);
            obj.SetValue(BelowProperty, value);

            obj.SetValue(EasyBelowProperty, value);
        }

        /// <summary>
        ///  Identifies the <see cref="RelativePanel.EasyAlignWithProperty"/> XAML attached property.
        /// </summary>

        public static readonly AttachedProperty<object> EasyBelowProperty =
            AvaloniaProperty.RegisterAttached<RelativePanel, Layoutable, object>("EasyBelow");

    }
}
