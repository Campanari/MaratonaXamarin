using MaratonaXamarin.Services;
using MaratonaXamarin.UWP.Services;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using Windows.Networking.PushNotifications;
using Xamarin.Forms;

[assembly: Dependency(typeof(NotificacaoService))]
namespace MaratonaXamarin.UWP.Services
{
    public class NotificacaoService : INotificacaoService
    {
        public async Task Registrar(string token)
        {
            var channel = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();

            const string templateBodyWNS = "<toast><visual><binding template=\"ToastText01\"><text id=\"1\">$(messageParam)</text></binding></visual></toast>";

            var headers = new JObject
            {
                ["X-WNS-Type"] = "wns/toast"
            };
            
            var templates = new JObject
            {
                ["genericMessage"] = new JObject
                {
                    { "body", templateBodyWNS },
                    { "headers", headers }
                }
            };

            await AzureService.Cliente.GetPush().RegisterAsync(channel.Uri, templates);
        }

        public async Task Desregistrar() =>
            await AzureService.Cliente.GetPush().UnregisterAsync();
    }
}
