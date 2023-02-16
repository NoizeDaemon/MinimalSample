using Avalonia.Data;
using ReactiveUI;
using System;
using System.Diagnostics;
using System.Reactive;

namespace MinimalSample.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //For Method 1:
        private (string, string) tag;
        public (string, string) Tag
        {
            get => tag;
            set => this.RaiseAndSetIfChanged(ref tag, value);
        }

        //For Method 2:
        private bool panelTag2; //To notify panel of change (doesn't happen automatically for some reason)
        public bool PanelTag2
        {
            get => panelTag2;
            set => this.RaiseAndSetIfChanged(ref panelTag2, value);
        }

        private string alignHorizontalCenterWith;
        public string AlignHorizontalCenterWith
        {
            get => alignHorizontalCenterWith;
            set => this.RaiseAndSetIfChanged(ref alignHorizontalCenterWith, value);
        }

        private string alignVerticalCenterWith;
        public string AlignVerticalCenterWith
        {
            get => alignVerticalCenterWith;
            set => this.RaiseAndSetIfChanged(ref alignVerticalCenterWith, value);
        }

        private string rightOf;
        public string RightOf
        {
            get => rightOf;
            set => this.RaiseAndSetIfChanged(ref rightOf, value);
        }

        private string leftOf;
        public string LeftOf
        {
            get => leftOf;
            set => this.RaiseAndSetIfChanged(ref leftOf, value);
        }

        private string above;
        public string Above
        {
            get => above;
            set => this.RaiseAndSetIfChanged(ref above, value);
        }

        private string below;
        public string Below
        {
            get => below;
            set => this.RaiseAndSetIfChanged(ref below, value);
        }
        ///////////

        //For Method 3:
        private bool panelTag3; //To notify panel of change (doesn't happen automatically for some reason)
        public bool PanelTag3
        {
            get => panelTag3;
            set => this.RaiseAndSetIfChanged(ref panelTag3, value);
        }

        private string easyRightTarget;
        public string EasyRightTarget
        {
            get => easyRightTarget;
            set => this.RaiseAndSetIfChanged(ref easyRightTarget, value);
        }

        private string easyLeftTarget;
        public string EasyLeftTarget
        {
            get => easyLeftTarget;
            set => this.RaiseAndSetIfChanged(ref easyLeftTarget, value);
        }

        private string easyAboveTarget;
        public string EasyAboveTarget
        {
            get => easyAboveTarget;
            set => this.RaiseAndSetIfChanged(ref easyAboveTarget, value);
        }

        private string easyBelowTarget;
        public string EasyBelowTarget
        {
            get => easyBelowTarget;
            set => this.RaiseAndSetIfChanged(ref easyBelowTarget, value);
        }
        ///////////

        public ReactiveCommand<string, Unit> SetDirectionClick { get; }

        public MainViewModel()
        {            
            SetDirectionClick = ReactiveCommand.Create<string>(direction =>
            {
                ResetDirection();
                SetDirection(direction);
            });
        }

        void SetDirection(string direction)
        {
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