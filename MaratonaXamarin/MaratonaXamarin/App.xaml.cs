using MaratonaXamarin.Services;
using MaratonaXamarin.ViewModels;
using MaratonaXamarin.Views;
using Microsoft.WindowsAzure.MobileServices;
using MVVMonkey.Core.Services;
using MVVMonkey.Core.ViewModel;
using Xamarin.Forms;

namespace MaratonaXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeMessages();
            this.Configure(InitializeNavigation);
        }

        private void InitializeMessages()
        {
            MessagingCenter.Subscribe<ViewModelBase, MobileServiceUser>(this, Mensagens.UsuarioAutenticado, OnUsuarioAutenticado);
        }

        private void InitializeNavigation(INavigationService navigationService)
        {
            navigationService.Configure<Login, LoginViewModel>();
            navigationService.Configure<Principal, PrincipalViewModel>();

            navigationService.Start<LoginViewModel>(navigationPage: false);
        }

        public void OnUsuarioAutenticado(ViewModelBase viewModel, MobileServiceUser usuario)
        {
            DependencyService.Get<INotificacaoService>()
                .Registrar(usuario.MobileServiceAuthenticationToken);

            DependencyService.Get<INavigationService>()
                .Start<PrincipalViewModel>(new NavigationParameters(nameof(PrincipalViewModel.Parametros.Usuario), usuario));
        }
    }
}
