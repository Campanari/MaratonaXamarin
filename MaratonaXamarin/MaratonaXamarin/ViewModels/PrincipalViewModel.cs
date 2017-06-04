using Microsoft.WindowsAzure.MobileServices;
using MVVMonkey.Core.Services;
using MVVMonkey.Core.ViewModel;

namespace MaratonaXamarin.ViewModels
{
    class PrincipalViewModel : ViewModelBase, INavigationViewModel
    {
        public static class Parametros
        {
            public readonly static string Usuario = nameof(Usuario);
        }

        private MobileServiceUser Usuario { get; set; }
        
        public void OnNavigate(NavigationParameters navigationParameters)
        {
            Usuario = navigationParameters.GetValue<MobileServiceUser>(nameof(Parametros.Usuario));
        }
    }
}
