using Microsoft.AspNetCore.SignalR;
using Models;
namespace NewSHAT.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(MensajeUsuario mensajeUsuario)
        {
            await Clients.All.SendAsync("ReceivedMessage", mensajeUsuario);
        }
    }
}
