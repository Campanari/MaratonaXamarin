using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace MaratonaXamarin.Services
{
    public interface INotificacaoService
    {
        Task Registrar(string token);
        Task Desregistrar();
    }
}
