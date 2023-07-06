using Debt_relations_project_version1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Debt_relations_project_version1.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ILogger<RegistrationController> _logger;

        public RegistrationController(ILogger<RegistrationController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult RegistationForm()
        {
            return View("Views/Registration/RegistrationForm.cshtml");
        }
        [HttpPost]
        public User RegistationForm(string username,string mail)
        {
            var user = new User(username, mail);
            return user;
        }

    }
}
