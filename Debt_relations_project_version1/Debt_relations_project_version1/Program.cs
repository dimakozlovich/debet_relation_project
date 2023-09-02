using Debt_relations_project_version1.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
var app = builder.Build();

// ������������� ������������� ��������� � �������������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Registration}/{action=Entrance}/{id?}");

app.MapHub<ChatHub>("/chat");

app.Run();
