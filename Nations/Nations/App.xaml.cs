using Prism;
using Prism.Ioc;
using Nations.ViewModels;
using Nations.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using Nations.Services.Interfaces;
using Nations.Services.Classes;
using Syncfusion.Licensing;
using Xamarin.Essentials;

namespace Nations
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            SyncfusionLicenseProvider.RegisterLicense("MzIyMjYwQDMxMzgyZTMyMmUzMFBYUGxzd0Nqc0lFMFo3MWFBWUpWZkVPT1hOY2JsUFMrRWRjeUhpRmVzanM9");

            InitializeComponent();

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await NavigationService.NavigateAsync($"NavigationPage/{nameof(MainPage)}");
            }
            else
            {
                await NavigationService.NavigateAsync($"NavigationPage/{nameof(CountriesPage)}");
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<CountryDetailPage, CountryDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<CountriesPage, CountriesPageViewModel>();
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.Register<IDataFilteringService, DataFilteringService>();
        }
    }
}
