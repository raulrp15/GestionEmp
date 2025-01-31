using ChatMaui.Client.ViewModels.Utils;
using Microsoft.AspNetCore.SignalR.Client;
using Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ChatMaui.Client.ViewModels
{
    public class vmChat : INotifyPropertyChanged
    {
        #region Atributos
        private readonly HubConnection connection;
        private string group;
        private string nick;
        private string msg;
        private ObservableCollection<MensajeUsuario> msgsList;
        private DelegateCommand sendCommand;
        private string grupoActual = "";
        #endregion

        #region Propiedades
        public string Group { get { return group; } set { group = value; NotifyPropertyChanged(); sendCommand.RaiseCanExecuteChanged(); } }
        public string Nick { get { return nick; } set { nick = value; NotifyPropertyChanged(); sendCommand.RaiseCanExecuteChanged(); } }
        public string Msg { get { return msg; } set { msg = value; NotifyPropertyChanged(); sendCommand.RaiseCanExecuteChanged(); } }
        public ObservableCollection<MensajeUsuario> MsgsList { get { return msgsList; } }
        public DelegateCommand SendCommand { get { return sendCommand; } }

        #endregion

        #region Constructor
        public vmChat()
        {
            msgsList = new ObservableCollection<MensajeUsuario>();
            sendCommand = new DelegateCommand(sendExecute, sendCanExecute);
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5111/chathub")
                .Build();

            connection.On<MensajeUsuario>("ReceivedMessageGroup", (m) =>
            {
                MainThread.InvokeOnMainThreadAsync(() => { 
                    msgsList.Add(m);
                    NotifyPropertyChanged(nameof(MsgsList));
                });
                NotifyPropertyChanged(nameof(MsgsList));
            });

            connect();
        }
        #endregion

        #region Conexiones
        // Metodo que inserta el mensaje recibido en la lista de mensajes
        private void getMessage(MensajeUsuario m)
        {
            msgsList.Add(m);
            NotifyPropertyChanged(nameof(MsgsList));
        }

        // Metodo que conecta al servidor de SignalR(ASP)
        private async void connect()
        {
            await connection.StartAsync();
        }
        #endregion

        #region Comandos
        // Metodo que manda el mensaje al grupo que pertence en el servidor
        private async void sendExecute()
        {
            MensajeUsuario mUser= new();
            mUser.Usuario = nick;
            mUser.Mensaje = msg;
            mUser.Grupo = group;

            if (!grupoActual.Equals(mUser.Grupo)) 
            {
                leaveGroup();
            }
            await connection.InvokeCoreAsync("JoinGroup", args: new[] { mUser.Grupo });
            grupoActual = mUser.Grupo;
            await connection.InvokeCoreAsync("SendGroupMessage", args: new[] {mUser});
        }

        private async void leaveGroup()
        {
            msgsList.Clear();
            await connection.InvokeCoreAsync("LeaveGroup", args: new[] { grupoActual });
            grupoActual = "";
        }

        // Funcion que comprueba que si todos los campos estan rellenos se habilita el boton de enviar
        private bool sendCanExecute()
        {
            bool can = false;

            if(!String.IsNullOrEmpty(msg) && !String.IsNullOrEmpty(nick) && !String.IsNullOrEmpty(group))
            {
                can = true;
            }

            return can;
        }
        #endregion

        #region NPCd
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
