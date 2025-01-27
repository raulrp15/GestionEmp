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

        public Task JoinGroup(MensajeUsuario mensajeUsuario)
        {
            return Groups.AddToGroupAsync(mensajeUsuario.Usuario, mensajeUsuario.Grupo);
        }

        public async Task SendGroupMessage(MensajeUsuario m)
        {
            await Groups.AddToGroupAsync(m.Usuario, m.Grupo);
            Clients.Group(m.Grupo).SendAsync(m.Usuario + " : " + m.Mensaje);
        }
    }
}
