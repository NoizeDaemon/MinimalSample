using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Interactivity;
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

        public MainView()
        {
            InitializeComponent();

            ((INotifyPropertyChanged)R2).PropertyChanged += RectanglePropertyChanged;

        }

        private void RectanglePropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (R2.Tag != null && R2.IsLoaded)
            {
                var tag = ((string, string))R2.Tag;
                var direction = tag.Item1;
                var target = this.FindControl<Rectangle>((string)tag.Item2);

                if (direction is "Left" or "Right")
                {
                    RelativePanel.SetAlignVerticalCenterWith(R2, target);
                    //HorizontalCenterWith = ""

                    if (direction is "Left")
                    {
                        RelativePanel.SetLeftOf(R2, target);
                        //RightOf = "";
                    }
                    else
                    {
                        //LeftOf = "";
                        RelativePanel.SetRightOf(R2, target);
                    }
                }
                else
                {
                    RelativePanel.SetAlignVerticalCenterWith(R2, target);
                    //VerticalCenterWith = "";

                    if (direction is "Above")
                    {
                        RelativePanel.SetAbove(R2, target);
                        //Below = "";
                    }
                    else
                    {
                        //Above = "";
                        RelativePanel.SetBelow(R2, target);
                    }
                }
            }
        }
    }
}