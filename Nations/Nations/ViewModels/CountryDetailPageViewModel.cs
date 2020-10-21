using Nations.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Nations.ViewModels
{
    public class CountryDetailPageViewModel : ViewModelBase
    {
        Country _country;

        public CountryDetailPageViewModel(
            INavigationService navigationService)
            : base(navigationService)
        {
            Title = Country.Name;
        }

        public Country Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }
    }
}
