using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TimeBilling.Maui.ViewModels
{
    public partial class MainPageViewModel: ObservableObject
    {
        [ObservableProperty]
        private string caption = "Click me";

        private int count = default;

        [RelayCommand]
        public void ButtonPressed()
        {
            count++;

            if (count == 1)
                Caption = $"Clicked {count} time";
            else
                Caption = $"Clicked {count} times";
        }
    }
}
