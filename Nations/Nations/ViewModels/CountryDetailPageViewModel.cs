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
    //TODO: Show all country's info
    public class CountryDetailPageViewModel : ViewModelBase
    {
        Country _country;



        public CountryDetailPageViewModel(
            INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Country details";
        }

        public Country Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("country"))
            {
                Country = parameters.GetValue<Country>("country");
                Title = Country.Name;
            }
        }
    }
}
