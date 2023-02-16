using Avalonia.Data;
using ReactiveUI;
using System;
using System.Diagnostics;
using System.Reactive;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MinimalSample.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        //For Method 1:
        [ObservableProperty]
        private (string, string) tag;


        //For Method 2:
        [ObservableProperty]
        private bool panelTag2; //To notify panel of change (doesn't happen automatically for some reason)


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

        //For Method 3:
        [ObservableProperty]
        private bool panelTag3; //To notify panel of change (doesn't happen automatically for some reason)

        [ObservableProperty]
        private string easyRightTarget;

        [ObservableProperty]
        private string easyLeftTarget;
       
        [ObservableProperty]
        private string easyAboveTarget;

        [ObservableProperty]
        private string easyBelowTarget;

        ///////////



        [RelayCommand]
        void SetDirection(string direction)
        {
            ResetDirection();
            
            //For Method 1:
            Tag = (direction, "R1");

            //For Method 2:
            if (direction is "Left" or "Right")
            {
                AlignVerticalCenterWith = "P1";
                if (direction is "Left") LeftOf = "P1";
                else RightOf = "P1";
            }
            else
            {
                AlignHorizontalCenterWith = "P1";
                if (direction is "Above") Above = "P1";
                else Below = "P1";
            }
            PanelTag2 = true;

            //For Method 3:
            if (direction is "Left") EasyLeftTarget = "G1";
            else if (direction is "Right") EasyRightTarget = "G1";
            else if (direction is "Above") EasyAboveTarget = "G1";
            else if (direction is "Below") EasyBelowTarget = "G1";
            PanelTag3 = true;
        }

        
        void ResetDirection()
        {
            //For Method 2:
            PanelTag2 = false;
            AlignHorizontalCenterWith = "";
            AlignVerticalCenterWith = "";
            LeftOf = "";
            RightOf = "";
            Above = "";
            Below = "";

            //For Method 3:
            PanelTag3 = false;
            EasyLeftTarget = "";
            EasyRightTarget = "";
            EasyAboveTarget = "";
            easyBelowTarget = "";
        }
    }
}