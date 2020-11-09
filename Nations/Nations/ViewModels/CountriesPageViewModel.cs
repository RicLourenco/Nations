﻿using Nations.Models;
using Nations.Services.Interfaces;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace Nations.ViewModels
{
    //TODO: Template
    //TODO: Default selection to user's country if there's location authorization on startup
    class CountriesPageViewModel : ViewModelBase
    {
        readonly INavigationService _navigationService;
        IDataFilteringService _dataFilteringService;
        readonly IApiService _apiService;

        bool _isRunning;

        string _search;
        List<Country> _myCountries;
        DelegateCommand _searchCommand;

        ObservableCollection<CountryViewModel> _countries;

        public CountriesPageViewModel(
            INavigationService navigationService,
            IApiService apiService,
            IDataFilteringService dataFilteringService) : base(navigationService)
        {
            Title = "Countries list";
            _navigationService = navigationService;
            _apiService = apiService;
            _dataFilteringService = dataFilteringService;

            LoadCountriesAsync();
        }

        public DelegateCommand SearchCommand => _searchCommand ?? (_searchCommand =
            new DelegateCommand(ShowCountries));

        public string Search
        {
            get => _search;
            set
            {
                SetProperty(ref _search, value);
                ShowCountries();
            }
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public ObservableCollection<CountryViewModel> Countries
        {
            get => _countries;
            set => SetProperty(ref _countries, value);
        }

        async void LoadCountriesAsync()
        {
            if(Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No internet connection", "OK");
                return;
            }

            IsRunning = true;

            string url = App.Current.Resources["UrlAPI"].ToString();

            Response response = await _apiService.GetCountriesAsync<Country>(
                url, "/rest/v2/all");

            IsRunning = false;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "OK");
                return;
            }

            _myCountries = (List<Country>)response.Result;

            ShowCountries();
        }

        void ShowCountries()
        {
            if (string.IsNullOrEmpty(Search))
            {
                Countries = new ObservableCollection<CountryViewModel>(
                    _myCountries.Select(c =>
                    new CountryViewModel(_navigationService)
                    {
                        Alpha2Code = _dataFilteringService.CheckString(c.Alpha2Code),
                        Alpha3Code = _dataFilteringService.CheckString(c.Alpha3Code),
                        AltSpellings = _dataFilteringService.CheckStringList(c.AltSpellings),
                        Area = c.Area,
                        Borders = _dataFilteringService.CheckStringList(c.Borders),
                        CallingCodes = _dataFilteringService.CheckStringList(c.CallingCodes),
                        Capital = _dataFilteringService.CheckString(c.Capital),
                        Cioc = _dataFilteringService.CheckString(c.Cioc),
                        Currencies = c.Currencies,
                        Demonym = _dataFilteringService.CheckString(c.Demonym),
                        Flag = c.Flag,
                        Gini = c.Gini,
                        Languages = c.Languages,
                        Latlng = c.Latlng,
                        Name = _dataFilteringService.CheckString(c.Name),
                        NativeName = _dataFilteringService.CheckString(c.NativeName),
                        NumericCode = _dataFilteringService.CheckString(c.NumericCode),
                        Population = c.Population,
                        Region = _dataFilteringService.CheckString(c.Region),
                        RegionalBlocs = c.RegionalBlocs,
                        Subregion = _dataFilteringService.CheckString(c.Subregion),
                        Timezones = _dataFilteringService.CheckStringList(c.Timezones),
                        TopLevelDomain = _dataFilteringService.CheckStringList(c.TopLevelDomain),
                        Translations = c.Translations
                    })
                    .ToList());
            }
            else
            {
                Countries = new ObservableCollection<CountryViewModel>(
                    _myCountries.Select(c =>
                    new CountryViewModel(_navigationService)
                    {
                        Alpha2Code = _dataFilteringService.CheckString(c.Alpha2Code),
                        Alpha3Code = _dataFilteringService.CheckString(c.Alpha3Code),
                        AltSpellings = _dataFilteringService.CheckStringList(c.AltSpellings),
                        Area = c.Area,
                        Borders = _dataFilteringService.CheckStringList(c.Borders),
                        CallingCodes = _dataFilteringService.CheckStringList(c.CallingCodes),
                        Capital = _dataFilteringService.CheckString(c.Capital),
                        Cioc = _dataFilteringService.CheckString(c.Cioc),
                        Currencies = c.Currencies,
                        Demonym = _dataFilteringService.CheckString(c.Demonym),
                        Flag = c.Flag,
                        Gini = c.Gini,
                        Languages = c.Languages,
                        Latlng = c.Latlng,
                        Name = _dataFilteringService.CheckString(c.Name),
                        NativeName = _dataFilteringService.CheckString(c.NativeName),
                        NumericCode = _dataFilteringService.CheckString(c.NumericCode),
                        Population = c.Population,
                        Region = _dataFilteringService.CheckString(c.Region),
                        RegionalBlocs = c.RegionalBlocs,
                        Subregion = _dataFilteringService.CheckString(c.Subregion),
                        Timezones = _dataFilteringService.CheckStringList(c.Timezones),
                        TopLevelDomain = _dataFilteringService.CheckStringList(c.TopLevelDomain),
                        Translations = c.Translations
                    })
                    .Where(c => c.Name.ToLower().Contains(Search.ToLower()))
                    .ToList());
            }
        }
    }
}
