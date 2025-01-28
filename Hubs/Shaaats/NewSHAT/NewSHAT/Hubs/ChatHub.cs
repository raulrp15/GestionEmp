using Microsoft.AspNetCore.SignalR;
using Models;
namespace NewSHAT.Hubs
{
    public class ChatHub : Hub
    {
        #region Todos
        public async Task SendMessage(MensajeUsuario mensajeUsuario)
        {
            await Clients.All.SendAsync("ReceivedMessage", mensajeUsuario);
        }
        #endregion

        #region Grupos
        public Task JoinGroup(MensajeUsuario mensajeUsuario)
        {
            return Groups.AddToGroupAsync(mensajeUsuario.Usuario, mensajeUsuario.Grupo);
        }

        public async Task SendGroupMessage(MensajeUsuario m)
        {
            await Clients.Group(m.Grupo).SendAsync("ReceivedMessageGroup", m);
        }
        #endregion
    }
}
