using MaratonaXamarin.Services;
using MaratonaXamarin.ViewModels;
using MaratonaXamarin.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
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

        protected override void OnStart()
        {
            base.OnStart();

            AppCenter.Start("android=fe002865-c861-4e56-b25b-f257295e54ec;", typeof(Analytics), typeof(Crashes));
        }
    }
}
