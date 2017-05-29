using System;
using MaratonaXamarin.Services;
using Microsoft.WindowsAzure.MobileServices;
using MVVMonkey.Core.Services;
using MVVMonkey.Core.ViewModel;
using Xamarin.Forms;

namespace MaratonaXamarin.ViewModels
{
    class PrincipalViewModel : ViewModelBase, INavigationViewModel
    {
        private INotificacaoService NotificacaoService = DependencyService.Get<INotificacaoService>();
        public MobileServiceUser Usuario { get; private set; }
        
        ~PrincipalViewModel()
        {
            if (Usuario != null)
                NotificacaoService.Desregistrar();
        }

        public void OnNavigate(NavigationParameters navigationParameters)
        {
            Usuario = navigationParameters.GetValue<MobileServiceUser>(nameof(Usuario));

            if (Usuario != null)
                NotificacaoService.Registrar(Usuario.MobileServiceAuthenticationToken);
        }
    }
}
