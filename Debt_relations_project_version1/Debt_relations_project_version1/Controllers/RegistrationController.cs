﻿using Debt_relations_project_version1.Models;
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
        public IActionResult Entrance()
        {
            return View("Views/Registration/Entrance.cshtml");
        }
        [HttpPost]
        public User Entrance(string username,string mail)
        {
            var user = new User(username, mail);
            return user;
        }


        [HttpGet]
        public IActionResult Registration()
        {
            return View("Views/Registration/Registration.cshtml");
        }
        [HttpPost]
        public void Registration(string username, string mail, string password)
        {
            var User = new User(username,mail,password);
        }

    }
}
