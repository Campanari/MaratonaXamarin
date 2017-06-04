using MaratonaXamarin.Android.Services;
using MaratonaXamarin.Services;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(AutenticacaoService))]
namespace MaratonaXamarin.Android.Services
{
    public class AutenticacaoService : IAutenticaoService
    {
        public async Task<MobileServiceUser> Autenticar(MobileServiceClient cliente, MobileServiceAuthenticationProvider provedor)
            => await cliente.LoginAsync(Forms.Context, provedor);
    }
}
