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
        private bool panelTag; //To notify panel of change (doesn't happen automatically for some reason)
        public bool PanelTag
        {
            get => panelTag;
            set => this.RaiseAndSetIfChanged(ref panelTag, value);
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

        //For Method 3:
        //private string easyRightTarget;
        //public string EasyRightTarget
        //{
        //    get => easyRightTarget;
        //    set => this.RaiseAndSetIfChanged(ref easyRightTarget, value);
        //}

        //private string easyLeftTarget;
        //public string EasyLeftTarget
        //{
        //    get => easyLeftTarget;
        //    set => this.RaiseAndSetIfChanged(ref easyLeftTarget, value);
        //}

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

            PanelTag = true;

            //For Method 3:
            //if (direction is "Left")
            //{
            //    EasyLeftTarget = "P1";
            //    //EasyRightTarget = "";
            //}
            //else if (direction is "Right")
            //{
            //    EasyRightTarget = "P1";
            //    //EasyLeftTarget = ""; 
            //}
        }

        //For Method 2:
        void ResetDirection()
        {
            PanelTag = false;
            AlignHorizontalCenterWith = "";
            AlignVerticalCenterWith = "";
            LeftOf = "";
            RightOf = "";
            Above = "";
            Below = "";
        }
    }
}