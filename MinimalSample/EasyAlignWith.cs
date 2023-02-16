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
      
        [ResolveByName]
        public static string GetEasyAlignDirection(AvaloniaObject obj)
        {
            return (string)obj.GetValue(EasyAlignDirectionProperty);
        }

        public static void SetEasyRightOf(AvaloniaObject obj, string value)
        {
            obj.SetValue(EasyAlignDirectionProperty, value);
        }

        public static readonly AttachedProperty<string> EasyAlignDirectionProperty =
            AvaloniaProperty.RegisterAttached<RelativePanel, Layoutable, string>("EasyAlignDirection");


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
            if (value != AttachedProperty<object>.UnsetValue)
            {
                if (RelativePanel.GetLeftOf(obj) == value) RelativePanel.SetLeftOf(obj, AttachedProperty<object>.UnsetValue);
                if (RelativePanel.GetAbove(obj) == value) RelativePanel.SetAbove(obj, AttachedProperty<object>.UnsetValue);
                if (RelativePanel.GetBelow(obj) == value) RelativePanel.SetBelow(obj, AttachedProperty<object>.UnsetValue);
                if (RelativePanel.GetAlignHorizontalCenterWith(obj) == value) RelativePanel.SetAlignHorizontalCenterWith(obj, AttachedProperty<object>.UnsetValue);
                if (GetEasyLeftOf(obj) == value) SetEasyLeftOf(obj, AttachedProperty<object>.UnsetValue);
                if (GetEasyAbove(obj) == value) SetEasyAbove(obj, AttachedProperty<object>.UnsetValue);
                if (GetEasyBelow(obj) == value) SetEasyBelow(obj, AttachedProperty<object>.UnsetValue);
            }

            RelativePanel.SetAlignVerticalCenterWith(obj,value);
            RelativePanel.SetRightOf(obj, value);

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
            if (value != AttachedProperty<object>.UnsetValue)
            {
                if (RelativePanel.GetRightOf(obj) == value) RelativePanel.SetRightOf(obj, AttachedProperty<object>.UnsetValue);
                if (RelativePanel.GetAbove(obj) == value) RelativePanel.SetAbove(obj, AttachedProperty<object>.UnsetValue);
                if (RelativePanel.GetBelow(obj) == value) RelativePanel.SetBelow(obj, AttachedProperty<object>.UnsetValue);
                if (RelativePanel.GetAlignHorizontalCenterWith(obj) == value) RelativePanel.SetAlignHorizontalCenterWith(obj, AttachedProperty<object>.UnsetValue);
                if (GetEasyRightOf(obj) == value) SetEasyRightOf(obj, AttachedProperty<object>.UnsetValue);
                if (GetEasyAbove(obj) == value) SetEasyAbove(obj, AttachedProperty<object>.UnsetValue);
                if (GetEasyBelow(obj) == value) SetEasyBelow(obj, AttachedProperty<object>.UnsetValue);
            }



            RelativePanel.SetAlignVerticalCenterWith(obj, value);
            RelativePanel.SetLeftOf(obj, value);

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
            if (value != AttachedProperty<object>.UnsetValue)
            {
                if (RelativePanel.GetRightOf(obj) == value) RelativePanel.SetRightOf(obj, AttachedProperty<object>.UnsetValue);
                if (RelativePanel.GetLeftOf(obj) == value) RelativePanel.SetLeftOf(obj, AttachedProperty<object>.UnsetValue);
                if (RelativePanel.GetBelow(obj) == value) RelativePanel.SetBelow(obj, AttachedProperty<object>.UnsetValue);
                if (RelativePanel.GetAlignVerticalCenterWith(obj) == value) RelativePanel.SetAlignVerticalCenterWith(obj, AttachedProperty<object>.UnsetValue);
                if (GetEasyRightOf(obj) == value) SetEasyRightOf(obj, AttachedProperty<object>.UnsetValue);
                if (GetEasyLeftOf(obj) == value) SetEasyLeftOf(obj, AttachedProperty<object>.UnsetValue);
                if (GetEasyBelow(obj) == value) SetEasyBelow(obj, AttachedProperty<object>.UnsetValue);
            }


            RelativePanel.SetAlignHorizontalCenterWith(obj, value);
            RelativePanel.SetAbove(obj, value);

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
            if (value != AttachedProperty<object>.UnsetValue)
            {
                if (RelativePanel.GetRightOf(obj) == value) RelativePanel.SetRightOf(obj, AttachedProperty<object>.UnsetValue);
                if (RelativePanel.GetLeftOf(obj) == value) RelativePanel.SetLeftOf(obj, AttachedProperty<object>.UnsetValue);
                if (RelativePanel.GetBelow(obj) == value) RelativePanel.SetBelow(obj, AttachedProperty<object>.UnsetValue);
                if (RelativePanel.GetAlignVerticalCenterWith(obj) == value) RelativePanel.SetAlignVerticalCenterWith(obj, AttachedProperty<object>.UnsetValue);
                if (GetEasyRightOf(obj) == value) SetEasyRightOf(obj, AttachedProperty<object>.UnsetValue);
                if (GetEasyLeftOf(obj) == value) SetEasyLeftOf(obj, AttachedProperty<object>.UnsetValue);
                if (GetEasyAbove(obj) == value) SetEasyAbove(obj, AttachedProperty<object>.UnsetValue);
            }



            RelativePanel.SetAlignHorizontalCenterWith(obj, value);
            RelativePanel.SetBelow(obj, value);

            obj.SetValue(EasyBelowProperty, value);
        }

        /// <summary>
        ///  Identifies the <see cref="RelativePanel.EasyAlignWithProperty"/> XAML attached property.
        /// </summary>

        public static readonly AttachedProperty<object> EasyBelowProperty =
            AvaloniaProperty.RegisterAttached<RelativePanel, Layoutable, object>("EasyBelow");

    }
}
