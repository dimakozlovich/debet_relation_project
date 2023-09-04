using Microsoft.AspNetCore.SignalR;
namespace Debt_relations_project_version1.Models
{
	public class ChatHub : Hub
	{
		public async Task Send(string message)
		{
			await this.Clients.All.SendAsync(message);
		}
	}
}
