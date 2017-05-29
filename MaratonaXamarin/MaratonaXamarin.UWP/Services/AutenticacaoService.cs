using MaratonaXamarin.Services;
using MaratonaXamarin.UWP.Services;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(AutenticacaoService))]
namespace MaratonaXamarin.UWP.Services
{
    public class AutenticacaoService : IAutenticaoService
    {
        public async Task<MobileServiceUser> Autenticar(MobileServiceClient cliente, MobileServiceAuthenticationProvider provedor)
            => await cliente.LoginAsync(provedor);
    }
}
