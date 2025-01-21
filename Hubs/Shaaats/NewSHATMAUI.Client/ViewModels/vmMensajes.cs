using Microsoft.AspNetCore.SignalR.Client;
using Models;
using NewSHATMAUI.Client.ViewModels.Utils;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NewSHATMAUI.Client.ViewModels
{
    internal class vmMensajes
    {
        private HubConnection connection;
        private MensajeUsuario mensajeUsuario;
        private string user;
        private string message;
        private DelegateCommand sendCommand;
        private ObservableCollection<string> messList;
        private string completeMessage;
        public MensajeUsuario MensajeUsuario { get {  return mensajeUsuario; } }
        public string User { get { return user; } set { user = value; } }
        public string Message { get { return message; } set { message = value; } }
        public DelegateCommand SendCommand { get { return sendCommand; } }

        public vmMensajes() 
        {
            connection = new HubConnectionBuilder().WithUrl("http://localhost:5111").Build();
            sendCommand = new DelegateCommand(sendMessage);
        }

        private async void sendMessage()
        {
            mensajeUsuario.Mensaje = message;
            mensajeUsuario.Usuario = user;
             
        }

        #region Notify
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
