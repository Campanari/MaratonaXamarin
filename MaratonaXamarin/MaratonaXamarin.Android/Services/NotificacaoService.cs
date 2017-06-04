using MaratonaXamarin.Android.Services;
using MaratonaXamarin.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(NotificacaoService))]
namespace MaratonaXamarin.Android.Services
{
    public class NotificacaoService : INotificacaoService
    {
        public async Task Registrar(string token) =>
            await Task.Factory.StartNew(() => { });

        public async Task Desregistrar() =>
            await Task.Factory.StartNew(() => { });
    }
}
