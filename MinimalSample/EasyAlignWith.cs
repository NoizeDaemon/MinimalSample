using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Layout;
using MinimalSample.Models;
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
            AffectsParentArrange<RelativePanel>(DirectionProperty, TargetProperty);
            AffectsParentMeasure<RelativePanel>(DirectionProperty, TargetProperty);

            DirectionProperty.Changed.AddClassHandler<AvaloniaObject>(OnDirectionTargetPropertyChanged);
            TargetProperty.Changed.AddClassHandler<AvaloniaObject>(OnDirectionTargetPropertyChanged);
        }

        private static void OnDirectionTargetPropertyChanged(AvaloniaObject obj, AvaloniaPropertyChangedEventArgs e)
        {
            //var parent = obj.GetValue(ParentProperty);
            Direction direction = obj.GetValue(DirectionProperty);
            var targetValue = obj.GetValue(TargetProperty);

            //if (parent is ContentPresenter)
            //{
            //    //parent.SetValue(NameProperty, obj.GetValue(NameProperty));
            //    obj = parent;
            //}

            if (direction != Direction.Unset && targetValue != AvaloniaProperty.UnsetValue && targetValue != null)
            {
                if (direction is Direction.RightOf)
                {
                    if (obj.GetValue(LeftOfProperty) == targetValue) RelativePanel.SetLeftOf(obj, AvaloniaProperty.UnsetValue);
                    if (obj.GetValue(AboveProperty) == targetValue) RelativePanel.SetAbove(obj, AvaloniaProperty.UnsetValue);
                    if (obj.GetValue(BelowProperty) == targetValue) RelativePanel.SetBelow(obj, AvaloniaProperty.UnsetValue);
                    if (obj.GetValue(AlignHorizontalCenterWithProperty) == targetValue) RelativePanel.SetAlignHorizontalCenterWith(obj, AvaloniaProperty.UnsetValue);

                    RelativePanel.SetAlignVerticalCenterWith(obj, targetValue);
                    RelativePanel.SetRightOf(obj, targetValue);
                }
                else if (direction is Direction.LeftOf)
                {
                    if (obj.GetValue(RightOfProperty) == targetValue) RelativePanel.SetRightOf(obj, AvaloniaProperty.UnsetValue);
                    if (obj.GetValue(AboveProperty) == targetValue) RelativePanel.SetAbove(obj, AvaloniaProperty.UnsetValue);
                    if (obj.GetValue(BelowProperty) == targetValue) RelativePanel.SetBelow(obj, AvaloniaProperty.UnsetValue);
                    if (obj.GetValue(AlignHorizontalCenterWithProperty) == targetValue) RelativePanel.SetAlignHorizontalCenterWith(obj, AvaloniaProperty.UnsetValue);

                    RelativePanel.SetAlignVerticalCenterWith(obj, targetValue);
                    RelativePanel.SetLeftOf(obj, targetValue);
                }
                else if (direction is Direction.Above)
                {
                    if (obj.GetValue(RightOfProperty) == targetValue) RelativePanel.SetRightOf(obj, AvaloniaProperty.UnsetValue);
                    if (obj.GetValue(LeftOfProperty) == targetValue) RelativePanel.SetLeftOf(obj, AvaloniaProperty.UnsetValue);
                    if (obj.GetValue(BelowProperty) == targetValue) RelativePanel.SetBelow(obj, AvaloniaProperty.UnsetValue);
                    if (obj.GetValue(AlignVerticalCenterWithProperty) == targetValue) RelativePanel.SetAlignVerticalCenterWith(obj, AvaloniaProperty.UnsetValue);


                    RelativePanel.SetAlignHorizontalCenterWith(obj, targetValue);
                    RelativePanel.SetAbove(obj, targetValue);
                }
                else if (direction is Direction.Below)
                {
                    if (obj.GetValue(RightOfProperty) == targetValue) RelativePanel.SetRightOf(obj, AvaloniaProperty.UnsetValue);
                    if (obj.GetValue(LeftOfProperty) == targetValue) RelativePanel.SetLeftOf(obj, AvaloniaProperty.UnsetValue);
                    if (obj.GetValue(AboveProperty) == targetValue) RelativePanel.SetAbove(obj, AvaloniaProperty.UnsetValue);
                    if (obj.GetValue(AlignVerticalCenterWithProperty) == targetValue) RelativePanel.SetAlignVerticalCenterWith(obj, AvaloniaProperty.UnsetValue);


                    RelativePanel.SetAlignHorizontalCenterWith(obj, targetValue);
                    RelativePanel.SetBelow(obj, targetValue);
                }
            }
        }

        /////////////////
        /// Direction ///
        /////////////////

        public static Direction GetDirection(AvaloniaObject obj)
        {
            return obj.GetValue(DirectionProperty);
        }

        public static void SetDirection(AvaloniaObject obj, Direction value)
        {
            obj.SetValue(DirectionProperty, value);
        }

        public static readonly AttachedProperty<Direction> DirectionProperty =
            AvaloniaProperty.RegisterAttached<RelativePanel, Layoutable, Direction>("Direction");


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
    }
}
