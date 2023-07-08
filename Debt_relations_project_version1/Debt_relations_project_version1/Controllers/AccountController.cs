using Microsoft.AspNetCore.Mvc;

namespace Debt_relations_project_version1.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
