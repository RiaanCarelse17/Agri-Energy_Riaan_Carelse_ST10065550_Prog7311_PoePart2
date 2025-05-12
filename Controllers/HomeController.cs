using Agri_Energy_Riaan_Carelse_ST10065550_Prog7311_PoePart2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace Agri_Energy_Riaan_Carelse_ST10065550_Prog7311_PoePart2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            if (model.UserType == "Farmer")
            {
                var farmer = _context.Farmers.FirstOrDefault(f => f.FirstName == model.FirstName && f.Password == model.Password);
                if (farmer != null)
                {
                    TempData["UserType"] = "Farmer";
                    TempData["UserId"] = farmer.FarmerId;
                    TempData["UserName"] = farmer.FirstName;
                    return RedirectToAction("Dashboard", "Farmer", new { id = farmer.FarmerId });
                }
            }
            else if (model.UserType == "Employee")
            {
                var employee = _context.Employees.FirstOrDefault(e => e.FirstName == model.FirstName && e.Password == model.Password);
                if (employee != null)
                {
                    TempData["UserType"] = "Employee";
                    TempData["UserId"] = employee.EmployeeId;
                    TempData["UserName"] = employee.FirstName;
                    return RedirectToAction("Dashboard", "Employee", new { id = employee.EmployeeId });
                }
            }

            ModelState.AddModelError("", "Invalid login credentials");
            return View("Index", model);
        }


        public IActionResult Logout()
        {
            TempData.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
