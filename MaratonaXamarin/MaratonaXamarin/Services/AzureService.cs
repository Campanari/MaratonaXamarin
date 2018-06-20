using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaratonaXamarin.Services
{
    public static class AzureService
    {
        private const string Url = "https://campanari.azurewebsites.net";

        private static MobileServiceClient _cliente;
        public static MobileServiceClient Cliente =>
            _cliente ?? (_cliente = new MobileServiceClient(Url))
;

        public static async Task<MobileServiceUser> LoginAsync()
        {
            var autenticacaoService = DependencyService.Get<IAutenticaoService>();
            var usuario = await autenticacaoService.Autenticar(Cliente, MobileServiceAuthenticationProvider.Facebook);

            if (usuario != null)
                return usuario;
            
            Device.BeginInvokeOnMainThread(async () => await Application.Current.MainPage.DisplayAlert("Ops!", "sahjkdahadskd", "OK"));

            return null;
        }
    }
}
