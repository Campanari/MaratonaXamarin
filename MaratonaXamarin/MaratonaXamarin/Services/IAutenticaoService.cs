using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace MaratonaXamarin.Services
{
    public interface IAutenticaoService
    {
        Task<MobileServiceUser> Autenticar(MobileServiceClient cliente, MobileServiceAuthenticationProvider provedor);
    }
}
