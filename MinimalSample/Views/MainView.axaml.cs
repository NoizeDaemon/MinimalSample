using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Data;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.VisualTree;
using DynamicData.Binding;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinimalSample.ViewModels;
using ReactiveUI;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;

namespace MinimalSample.Views
{
    public partial class MainView : UserControl
    {
        bool rectangleIsChanging = false;

        public MainView()
        {
            InitializeComponent();

            //For Method 1:
            ((INotifyPropertyChanged)R2).PropertyChanged += RectanglePropertyChanged;

            ////For Method 2:
            //((INotifyPropertyChanged)relativePanel2).PropertyChanged += PanelPropertyChanged;

            ////For Method 3:
            //((INotifyPropertyChanged)relativePanel3).PropertyChanged += PanelPropertyChanged;
        }

        private void PanelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            //For Method 2:
            relativePanel2.InvalidateMeasure();

            //For Method 3:
            relativePanel3.InvalidateMeasure();
        }

        private void RectanglePropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (R2.Tag != null && R2.IsLoaded && !rectangleIsChanging)
            {
                rectangleIsChanging = true;

                var tag = ((string, string))R2.Tag;
                var direction = tag.Item1;
                var target = this.FindControl<Rectangle>((string)tag.Item2);

                RelativePanel.SetAlignHorizontalCenterWith(R2, AttachedProperty<object>.UnsetValue);
                RelativePanel.SetAlignVerticalCenterWith(R2, AttachedProperty<object>.UnsetValue);

                RelativePanel.SetLeftOf(R2, AttachedProperty<object>.UnsetValue);
                RelativePanel.SetRightOf(R2, AttachedProperty<object>.UnsetValue);
                RelativePanel.SetBelow(R2, AttachedProperty<object>.UnsetValue);
                RelativePanel.SetAbove(R2, AttachedProperty<object>.UnsetValue);

                if (direction is "Left" or "Right")
                {
                    RelativePanel.SetAlignVerticalCenterWith(R2, target);

                    if (direction is "Left") RelativePanel.SetLeftOf(R2, target);
                    else RelativePanel.SetRightOf(R2, target);
                }
                else
                {
                    RelativePanel.SetAlignHorizontalCenterWith(R2, target);

                    if (direction is "Above") RelativePanel.SetAbove(R2, target);
                    else RelativePanel.SetBelow(R2, target);
                }
   
                //relativePanel1.InvalidateMeasure();
                rectangleIsChanging = false;
            }
        }
    }
}