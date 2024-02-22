using HaloDocWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HaloDocWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SubmitReq()
        {
            return View();
        }
        public IActionResult PatientLogin()
        {
            return View();
        }
        public IActionResult PatientForgotPass()
        {
            return View();
        }
        public IActionResult ResetPass()
        {
            return View();
        }
    }
}