using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Shapes;
using Avalonia.Controls.Generators;
using Avalonia.Data;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.VisualTree;
using DynamicData;
using DynamicData.Binding;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinimalSample.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;
using System.Collections.Generic;

namespace MinimalSample.Views
{
    public partial class MainView : UserControl
    {
        bool rectangleIsChanging = false;

        public MainView()
        {
            InitializeComponent();

            //For Method 1a:
            ((INotifyPropertyChanged)R2).PropertyChanged += RectanglePropertyChanged;           
        }

        //For Method 1a:
        private void RectanglePropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (R2.Tag != null && R2.IsLoaded && !rectangleIsChanging)
            {
                rectangleIsChanging = true;

                var tag = ((string, string))R2.Tag;
                var direction = tag.Item1;
                var target = this.FindControl<Rectangle>((string)tag.Item2);

                if(target is not null)
                {
                    RelativePanel.SetAlignHorizontalCenterWith(R2, AttachedProperty<object>.UnsetValue);
                    RelativePanel.SetAlignVerticalCenterWith(R2, AttachedProperty<object>.UnsetValue);

                    RelativePanel.SetLeftOf(R2, AttachedProperty<object>.UnsetValue);
                    RelativePanel.SetRightOf(R2, AttachedProperty<object>.UnsetValue);
                    RelativePanel.SetBelow(R2, AttachedProperty<object>.UnsetValue);
                    RelativePanel.SetAbove(R2, AttachedProperty<object>.UnsetValue);

                    if (direction is "LeftOf" or "RightOf")
                    {
                        RelativePanel.SetAlignVerticalCenterWith(R2, target);

                        if (direction is "LeftOf") RelativePanel.SetLeftOf(R2, target);
                        else RelativePanel.SetRightOf(R2, target);
                    }
                    else
                    {
                        RelativePanel.SetAlignHorizontalCenterWith(R2, target);

                        if (direction is "Above") RelativePanel.SetAbove(R2, target);
                        else RelativePanel.SetBelow(R2, target);
                    }
                }
                rectangleIsChanging = false;
            }
        }

        //For Method 1b:
        void OnResetButtonClick(object sender, RoutedEventArgs e)
        {
            var visuals = this.GetVisualDescendants();

            //Reset RelativePanels - does nothing
            var panels = visuals.Where(x => x is RelativePanel);

            foreach(var panel in panels)
            {
                ((RelativePanel)panel).InvalidateMeasure();
                ((RelativePanel)panel).InvalidateArrange();
            }
        }


        //void ItemNumberLoaded(object sender, RoutedEventArgs e)
        //{
        //    var control = sender as Control;
        //    var index = itemsControl1b.IndexFromContainer(control);
        //    Debug.WriteLine(index);
        //}






        //void OnItemsControlLoaded(object sender, RoutedEventArgs e)
        //{
        //    var itemsControl = (ItemsControl)sender;

        //    var visuals = (itemsControl.GetVisualDescendants()).ToObservable().ToObservableChangeSet<IEnumerable<Visual>>().AsObservableList();

        //    //var panel = (Panel)visuals.Where(x => x is RelativePanel).First();
        //    //panel.Children.CollectionChanged += OnContentPresenterCollectionChanged;

        //    //((ItemContainerGenerator)itemsControl.ItemContainerGenerator).Materialized += VisualContentLoaded;
        //}

        //void OnContentPresenterCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    var newContenPresenters = e.NewItems;

        //    foreach(ContentPresenter newPresenter in newContenPresenters)
        //    {
        //        newPresenter.Child.Loaded += VisualContentLoaded;                  
        //    }
        //}

        //private void VisualContentLoaded(object? sender, ItemContainerEventArgs e)
        //{
        //    var control = (Control)sender;

        //}
    }
}