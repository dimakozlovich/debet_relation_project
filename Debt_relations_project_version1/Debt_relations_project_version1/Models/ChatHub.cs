using Microsoft.AspNetCore.SignalR;
namespace Debt_relations_project_version1.Models
{
	public class ChatHub : Hub
	{
		public async Task Send(string message, string connectionId)
		{
			await this.Clients.Client(connectionId).SendAsync(message);
		}
	}
}
