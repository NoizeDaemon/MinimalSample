using ReactiveUI;
using System.Diagnostics;
using System.Reactive;

namespace MinimalSample.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string verticalCenterWith = "R1";
        public string VerticalCenterWith
        {
            get => verticalCenterWith;
            set => this.RaiseAndSetIfChanged(ref verticalCenterWith, value);
        }

        private string horizontalCenterWith = "";
        public string HorizontalCenterWith
        {
            get => horizontalCenterWith;
            set => this.RaiseAndSetIfChanged(ref horizontalCenterWith, value);
        }

        private string leftOf = "";
        public string LeftOf
        {
            get => leftOf;
            set => this.RaiseAndSetIfChanged(ref leftOf, value);
        }

        private string rightOf = "R1";
        public string RightOf
        {
            get => rightOf;
            set => this.RaiseAndSetIfChanged(ref rightOf, value);
        }

        private string above = "";
        public string Above
        {
            get => above;
            set => this.RaiseAndSetIfChanged(ref above, value);
        }

        private string below = "";
        public string Below
        {
            get => below;
            set => this.RaiseAndSetIfChanged(ref below, value);
        }

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
            Debug.WriteLine("Setting");
            if (direction is "Left" or "Right")
            {
                VerticalCenterWith = "R1";

                if (direction is "Left") LeftOf = "R1";
                else RightOf = "R1";
            }
            else
            {
                HorizontalCenterWith = "R1";

                if (direction is "Above") Above = "R1";
                else Below = "R1";
            }
        }

        void ResetDirection()
        {
            Debug.WriteLine("Resetting");
            VerticalCenterWith = "";
            HorizontalCenterWith = "";
            LeftOf = "";
            RightOf = "";
            Above = "";
            Below = "";
        }
    }
}