using Microsoft.AspNetCore.SignalR.Client;
using Models;
namespace NewSHATMAUI.Client
{
    public partial class MainPage : ContentPage
    {
        private readonly HubConnection connection;
        MensajeUsuario msgUser;
        public MainPage()
        {
            InitializeComponent();

            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5111/chathub").WithAutomaticReconnect().Build();

            connection.On<MensajeUsuario>("MessageReceived", (m) =>
            {
                mensajeCompleto.Text += $"{m.Usuario}: {m.Mensaje}";
            });
            Task.Run(() =>
            {
                Dispatcher.Dispatch(async () =>
                await connection.StartAsync());
            });
        }

        private async void Send(object sender, EventArgs e)
        {
            msgUser = new MensajeUsuario();
            msgUser.Usuario = User.Text;
            msgUser.Mensaje = Message.Text;
            await connection.InvokeCoreAsync("SendMessage", args: new[]
            { msgUser});
        }
    }

}
