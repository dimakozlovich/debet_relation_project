using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
namespace Debt_relations_project_version1
{
	public class CustomUserIdProvider : IUserIdProvider
	{
		public virtual string GetUserId(HubConnectionContext hubConnection)
		{
			return hubConnection.User?.Identity.Name;
		}
	}
}
