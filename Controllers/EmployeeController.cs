using Agri_Energy_Riaan_Carelse_ST10065550_Prog7311_PoePart2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Agri_Energy_Riaan_Carelse_ST10065550_Prog7311_PoePart2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        // Constructor to inject AppDbContext
        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        // Displays the Employee Dashboard
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }

        // GET: Show Add Farmer Form
        [HttpGet]
        public IActionResult AddFarmer()
        {
            return View();
        }

        // POST: Adds a new farmer to the database
        [HttpPost]
        public async Task<IActionResult> AddFarmer(Farmer farmer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Farmers.Add(farmer);
                    await _context.SaveChangesAsync();
                    ViewBag.Success = "Farmer added successfully!";
                    ModelState.Clear(); // Clear the form fields after successful submission
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Something went wrong: " + ex.Message;
                }
            }
            return View();
        }

        // GET: Displays the list of products for farmers
        [HttpGet]
        public async Task<IActionResult> ViewProducts(string categoryFilter, int? yearFilter, int? monthFilter)
        {
            IQueryable<Product> productsQuery = _context.Products.Include(p => p.Farmer);

            if (!string.IsNullOrWhiteSpace(categoryFilter))
            {
                productsQuery = productsQuery.Where(p =>
                    p.Category.ToLower().Contains(categoryFilter.Trim().ToLower()));
            }

            if (yearFilter.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.ProductionDate.Year == yearFilter.Value);
            }

            if (monthFilter.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.ProductionDate.Month == monthFilter.Value);
            }

            var products = await productsQuery.ToListAsync();
            return View(products);
        }

        // Logs out the user and redirects to the home page
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
