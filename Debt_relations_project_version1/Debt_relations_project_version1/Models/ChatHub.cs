using Microsoft.AspNetCore.SignalR;
namespace Debt_relations_project_version1.Models
{
	public class ChatHub : Hub
	{
		public async Task Send(string message, string to)
		{

			var userName = Context.User.Identity.Name;

			if (Context.UserIdentifier != to) // если получатель и текущий пользователь не совпадают
			{
				await Clients.User(Context.UserIdentifier).SendAsync("Receive", message, userName);
			}
		}
	}
}
