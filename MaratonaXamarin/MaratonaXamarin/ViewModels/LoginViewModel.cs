using MaratonaXamarin.Services;
using Microsoft.WindowsAzure.MobileServices;
using MVVMonkey.Core.Services;
using MVVMonkey.Core.ViewModel;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MaratonaXamarin.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        public ICommand LoginCommand => new Command(async () =>
        {
            try
            {
                var usuario = await AzureService.LoginAsync();
                
                NavigationService.Start<PrincipalViewModel>(new NavigationParameters(nameof(PrincipalViewModel.Usuario), usuario));
            }
            catch (Exception e)
            {
                await DisplayAlertService.DisplayAlertAsync("Facebook Login", e.Message, new DisplayAlertAction("OK"));
            }            
        });
    }
}
