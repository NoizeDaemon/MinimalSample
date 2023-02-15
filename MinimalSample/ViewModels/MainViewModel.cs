using Avalonia.Data;
using ReactiveUI;
using System;
using System.Diagnostics;
using System.Reactive;

namespace MinimalSample.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private (string, string) tag;
        public (string, string) Tag
        {
            get => tag;
            set => this.RaiseAndSetIfChanged(ref tag, value);
        }

        public ReactiveCommand<string, Unit> SetDirectionClick { get; }

        public MainViewModel()
        {            
            SetDirectionClick = ReactiveCommand.Create<string>(direction =>
            { 
                SetDirection(direction);
            });

            //this.WhenAnyValue(x => x.Tag)
            //    .ObserveOn(RxApp.MainThreadScheduler)
            //    .Subscribe(_ => Debug.WriteLine("Changed"));
        }

        void SetDirection(string direction)
        {
            Tag = (direction, "R1");

            //Debug.WriteLine("Setting");
            //Debug.WriteLine($"Direction {Tag.Item1}, Target {Tag.Item2}");
        }
    }
}