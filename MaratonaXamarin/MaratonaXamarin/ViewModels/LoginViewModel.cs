using MaratonaXamarin.Services;
using MVVMonkey.Core.Services;
using MVVMonkey.Core.ViewModel;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MaratonaXamarin.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        public LoginViewModel()
        {
            MessagingCenter.Subscribe<ViewModelBase, Exception>(this, Mensagens.ErroAoAutenticarUsuario, OnErroAoAutenticarUsuario);
        }

        ~LoginViewModel()
        {
            MessagingCenter.Unsubscribe<ViewModelBase, Exception>(this, Mensagens.ErroAoAutenticarUsuario);
        }

        public ICommand LoginCommand => new Command(async () =>
        {
            try
            {
                var usuario = await AzureService.LoginAsync();

                MessagingCenter.Send((ViewModelBase)this, Mensagens.UsuarioAutenticado, usuario);
            }
            catch (Exception e)
            {
                MessagingCenter.Send((ViewModelBase)this, Mensagens.ErroAoAutenticarUsuario, e);
            }            
        });

        public void OnErroAoAutenticarUsuario(ViewModelBase sender, Exception execption)
        {
            DisplayAlertService.DisplayAlertAsync("Facebook Login", execption.Message, new DisplayAlertAction("OK"));
        }
    }
}
