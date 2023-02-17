using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            AffectsParentMeasure<RelativePanel>(EasyRightOfProperty, EasyLeftOfProperty, EasyAboveProperty, EasyBelowProperty);

            DirectionProperty.Changed.AddClassHandler<AvaloniaObject>(OnDirectionTargetPropertyChanged);
            TargetProperty.Changed.AddClassHandler<AvaloniaObject>(OnDirectionTargetPropertyChanged);
            EasyRightOfProperty.Changed.AddClassHandler<AvaloniaObject>(OnEasyRightOfPropertyChanged);
            EasyLeftOfProperty.Changed.AddClassHandler<AvaloniaObject>(OnEasyLeftOfPropertyChanged);
            EasyAboveProperty.Changed.AddClassHandler<AvaloniaObject>(OnEasyAbovePropertyChanged);
            EasyBelowProperty.Changed.AddClassHandler<AvaloniaObject>(OnEasyBelowPropertyChanged);
        }

        private static void OnDirectionTargetPropertyChanged(AvaloniaObject obj, AvaloniaPropertyChangedEventArgs e)
        {
            if (obj.GetValue(DirectionProperty) != AvaloniaProperty.UnsetValue && obj.GetValue(TargetProperty) != AvaloniaProperty.UnsetValue && obj.GetValue(TargetProperty) != null)
            {
                string direction = obj.GetValue(DirectionProperty);
                var target = (AvaloniaObject)obj.GetValue(TargetProperty);

                if (direction is "RightOf")
                {
                    obj.SetValue(EasyRightOfProperty, target);
                }
                else if (direction is "LeftOf"){
                    obj.SetValue(EasyLeftOfProperty, target);
                }
                else if (direction is "Above")
                {
                    obj.SetValue(EasyAboveProperty, target);
                }
                else if (direction is "Below")
                {
                    obj.SetValue(EasyBelowProperty, target);
                }
                else
                {
                    Debug.WriteLine(e.Sender + "\n" + "Direction not valid");
                }

            }
        }

        /////////////////
        /// Direction ///
        /////////////////

        public static string GetDirection(AvaloniaObject obj)
        {
            return (string)obj.GetValue(DirectionProperty);
        }

        public static void SetDirection(AvaloniaObject obj, string value)
        {
            obj.SetValue(DirectionProperty, value);
        }

        public static readonly AttachedProperty<string> DirectionProperty =
            AvaloniaProperty.RegisterAttached<RelativePanel, Layoutable, string>("Direction");


        //////////////
        /// Target ///
        //////////////

        [ResolveByName]
        public static object GetTarget(AvaloniaObject obj)
        {
            return obj.GetValue(TargetProperty);
        }

        [ResolveByName]
        public static void SetTarget(AvaloniaObject obj, object value)
        {
            obj.SetValue(TargetProperty, value);
        }

        public static readonly AttachedProperty<object> TargetProperty =
            AvaloniaProperty.RegisterAttached<RelativePanel, Layoutable, object>("Target");


        /////////////
        /// RIGHT ///
        /////////////

        [ResolveByName]
        public static object GetEasyRightOf(AvaloniaObject obj)
        {
            return (object)obj.GetValue(EasyRightOfProperty);
        }

        [ResolveByName]
        public static void SetEasyRightOf(AvaloniaObject obj, object value)
        {
            obj.SetValue(EasyRightOfProperty, value);
        }

        public static readonly AttachedProperty<object> EasyRightOfProperty =
            AvaloniaProperty.RegisterAttached<RelativePanel, Layoutable, object>("EasyRightOf");

        private static void OnEasyRightOfPropertyChanged(AvaloniaObject obj, AvaloniaPropertyChangedEventArgs e)
        {
            object value = e.NewValue;

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
            obj.SetValue(RightOfProperty, value);
        }


        ////////////
        /// LEFT ///
        ////////////

        [ResolveByName]
        public static object GetEasyLeftOf(AvaloniaObject obj)
        {
            return (object)obj.GetValue(EasyLeftOfProperty);
        }

        [ResolveByName]
        public static void SetEasyLeftOf(AvaloniaObject obj, object value)
        {
            obj.SetValue(EasyLeftOfProperty, value);
        }

        public static readonly AttachedProperty<object> EasyLeftOfProperty =
            AvaloniaProperty.RegisterAttached<RelativePanel, Layoutable, object>("EasyLeftOf");

        private static void OnEasyLeftOfPropertyChanged(AvaloniaObject obj, AvaloniaPropertyChangedEventArgs e)
        {
            object value = e.NewValue;

            if (value != AvaloniaProperty.UnsetValue)
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
            }
        }


        /////////////
        /// Above ///
        /////////////

        [ResolveByName]
        public static object GetEasyAbove(AvaloniaObject obj)
        {
            return (object)obj.GetValue(EasyAboveProperty);
        }

        [ResolveByName]
        public static void SetEasyAbove(AvaloniaObject obj, object value)
        {
            obj.SetValue(EasyAboveProperty, value);
        }

        public static readonly AttachedProperty<object> EasyAboveProperty =
            AvaloniaProperty.RegisterAttached<RelativePanel, Layoutable, object>("EasyAbove");

        private static void OnEasyAbovePropertyChanged(AvaloniaObject obj, AvaloniaPropertyChangedEventArgs e)
        {
            object value = e.NewValue;

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
        }


        /////////////
        /// Below ///
        /////////////

        [ResolveByName]
        public static object GetEasyBelow(AvaloniaObject obj)
        {
            return (object)obj.GetValue(EasyBelowProperty);
        }

        [ResolveByName]
        public static void SetEasyBelow(AvaloniaObject obj, object value)
        {
            obj.SetValue(EasyBelowProperty, value);
        }

        public static readonly AttachedProperty<object> EasyBelowProperty =
            AvaloniaProperty.RegisterAttached<RelativePanel, Layoutable, object>("EasyBelow");

        private static void OnEasyBelowPropertyChanged(AvaloniaObject obj, AvaloniaPropertyChangedEventArgs e)
        {
            object value = e.NewValue;

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
        }
    }
}
