using MaratonaXamarin.ViewModels;
using MaratonaXamarin.Views;
using MVVMonkey.Core.Services;
using Xamarin.Forms;

namespace MaratonaXamarin
{
    public partial class App : Application
    {
        public App()
        {
            this.Configure(InitializeNavigation);
        }

        private void InitializeNavigation(INavigationService navigationService)
        {
            navigationService.Configure<Login, LoginViewModel>();
            navigationService.Configure<Principal, PrincipalViewModel>();

            navigationService.Start<LoginViewModel>(navigationPage: false);
        }
    }
}
