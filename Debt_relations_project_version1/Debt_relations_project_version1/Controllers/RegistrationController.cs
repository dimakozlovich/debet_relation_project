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
        public string RegistationForm(string username,string mail)
        {
            return username + " " + mail;
        }

    }
}
