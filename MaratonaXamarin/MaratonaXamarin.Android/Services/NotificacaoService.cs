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
            await Task.Factory.StartNew(() =>
            {
                //GcmClient.CheckDevice(Forms.Context);
                //GcmClient.CheckManifest(Forms.Context);

                //GcmClient.Register(Forms.Context, GcmBroadcastReceiver.SENDER_IDS);
            });

        public async Task Desregistrar() => await Task.Factory.StartNew(() => { } );//GcmClient.UnRegister(Forms.Context));
    }
}
