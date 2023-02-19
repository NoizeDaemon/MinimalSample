using Avalonia.Data;
using ReactiveUI;
using System;
using System.Diagnostics;
using System.Reactive;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MinimalSample.Models;
using DynamicData;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace MinimalSample.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        /////////////////////////////////////////
        /////////// Directly in Panel ///////////
        /////////////////////////////////////////

        //For Method 1a:
        [ObservableProperty]
        private (string, string) tag;

        //For Method 2a:
        [ObservableProperty]
        private string alignHorizontalCenterWith;

        [ObservableProperty]
        private string alignVerticalCenterWith;
        
        [ObservableProperty]
        private string rightOf;
       
        [ObservableProperty]
        private string leftOf;

        [ObservableProperty]
        private string above;

        [ObservableProperty]
        private string below;

        ///////////

        //For Method 3a:
        [ObservableProperty]
        private Direction direction;

        [ObservableProperty]
        private string target;

        ///////////

        [RelayCommand]
        void SetDirection(string directionInput)
        {
            var newDirection = Enum.Parse<Direction>(directionInput);

            //For Method 1a:
            Tag = (directionInput, "R1");

            //For Method 2a:
            ResetDirection();
            if (newDirection is Direction.LeftOf or Direction.RightOf)
            {
                AlignVerticalCenterWith = "P1";
                if (newDirection is Direction.LeftOf) LeftOf = "P1";
                else RightOf = "P1";
            }
            else
            {
                AlignHorizontalCenterWith = "P1";
                if (newDirection is Direction.Above) Above = "P1";
                else Below = "P1";
            }

            //For Method 3a:
            Direction = newDirection;
            Target = "G1";
        }

        //For Method 2a:
        void ResetDirection()
        {  
            AlignHorizontalCenterWith = "";
            AlignVerticalCenterWith = "";
            LeftOf = "";
            RightOf = "";
            Above = "";
            Below = "";
        }

        ////////////////////////////////////////////////////////////////////////////////
        /////////// In ItemsControl with RelativePanel as ItemsPanelTemplate ///////////
        ////////////////////////////////////////////////////////////////////////////////

        [ObservableProperty]
        private bool addLeftEnabled, addRightEnabled, addAboveEnabled, addBelowEnabled;

        private readonly SourceList<NumberItem> numberItemsSourceList = new();
        private readonly ReadOnlyObservableCollection<NumberItem> numberItems;
        public ReadOnlyObservableCollection<NumberItem> NumberItems => numberItems;

        public MainViewModel()
        {
            numberItemsSourceList
                .Connect()
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out numberItems)
                .Subscribe();


            numberItemsSourceList.Add(new NumberItem
            {
                Name = "N1",
                Number = 1,
                IsPrime = false,
                Direction = Direction.Unset
            });

            AddLeftEnabled = true;
            AddRightEnabled = true;
            AddAboveEnabled = true;
            AddBelowEnabled = true;
        }

        [RelayCommand]
        void AddDirection(string directionInput)
        {
            var newDirection = Enum.Parse<Direction>(directionInput);
            numberItemsSourceList.Add(new NumberItem
            {
                Name = "N" + (numberItemsSourceList.Count + 1),
                Number = numberItemsSourceList.Count + 1,
                IsPrime = false,
                Direction = newDirection,
                Neighbor = "N" + numberItemsSourceList.Count
            });
        }
    }
}