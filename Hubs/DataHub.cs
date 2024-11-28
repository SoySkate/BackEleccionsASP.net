using Microsoft.AspNetCore.SignalR;

namespace BackEleccionsM.Hubs
{
    public class DataHub : Hub
    {
        // Método para enviar mensajes a todos los clientes conectados
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
