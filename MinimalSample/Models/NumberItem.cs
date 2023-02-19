using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalSample.Models
{
    public partial class NumberItem : ObservableObject
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private int number;

        [ObservableProperty]
        private bool isPrime;

        [ObservableProperty]
        private Direction? direction;

        [ObservableProperty]
        private string? neighbor;
    }

    public enum Direction
    {
        Unset,
        RightOf,
        Above,
        LeftOf,
        Below
    }
}
