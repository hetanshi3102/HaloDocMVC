using HaloDocDataAccess.DataContext;
using HaloDocRepository.Repositories;
using HaloDocRepository.Interface;
using Microsoft.AspNetCore.Mvc;
using HaloDocDataAccess.ViewModels;
using HaloDocDataAccess.DataModels;
namespace HaloDocWeb.Controllers
{
    public class PatientDashboardController : Controller
    {
        private readonly HaloDocDbContext _context;
        private readonly IPatientService _patientService;
        private readonly IAuthService _authservice;

        public PatientDashboardController(HaloDocDbContext context, IPatientService patientService, IAuthService authService)
        {
            _context = context;
            _patientService = patientService;
            _authservice = authService;
        }

        public IActionResult Dashboard()
        {
            int? userId = HttpContext.Session.GetInt32("userId");

            if (userId == null)
            {
                return View("Error");
            }

            User? user = _context.Users.FirstOrDefault(u => u.UserId == userId);

            if (user != null)
            {
                PatientDashboard dashboardVM = new PatientDashboard();
                dashboardVM.UserId = user.UserId;
                dashboardVM.UserName = user.FirstName + " " + user.LastName;
                dashboardVM.Requests = _context.Requests.Where(req => req.UserId == user.UserId).ToList();
                List<int> fileCounts = new List<int>();
                foreach (var request in dashboardVM.Requests)
                {
                    int count = _context.RequestWiseFiles.Count(reqFile => reqFile.RequestId == request.RequestId);
                    fileCounts.Add(count);
                }
                dashboardVM.DocumentCount = fileCounts;
                return View("Dashboard", dashboardVM);
            }

            return View("Error");
        } 
    }
}
