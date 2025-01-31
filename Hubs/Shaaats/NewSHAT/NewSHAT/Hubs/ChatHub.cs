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
        public Task JoinGroup(string grupo)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, grupo);
        }

        public async Task SendGroupMessage(MensajeUsuario m)
        {
            await Clients.Group(m.Grupo).SendAsync("ReceivedMessageGroup", m);
        }
        public Task LeaveGroup(string g)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, g);
        }
        #endregion
    }
}
