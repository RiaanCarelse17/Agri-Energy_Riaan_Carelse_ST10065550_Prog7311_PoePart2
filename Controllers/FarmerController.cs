using Agri_Energy_Riaan_Carelse_ST10065550_Prog7311_PoePart2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Agri_Energy_Riaan_Carelse_ST10065550_Prog7311_PoePart2.Controllers
{
    public class FarmerController : Controller
    {
        private readonly AppDbContext _context;

        public FarmerController(AppDbContext context)
        {
            _context = context;
        }

        //  Displays the Farmer Dashboard with their own products
        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            int? farmerId = HttpContext.Session.GetInt32("FarmerId");

            if (farmerId == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var products = await _context.Products
                .Where(p => p.FarmerId == farmerId)
                .ToListAsync();

            return View(products);
        }

        // Displays the Add Product form
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View(new Product());
        }

        // Handles product submission
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            int? farmerId = HttpContext.Session.GetInt32("FarmerId");

            if (farmerId == null)
            {
                return RedirectToAction("Login", "Home");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    product.FarmerId = farmerId.Value;
                    product.ProductionDate = product.ProductionDate.Date;

                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Product added successfully!";
                    return RedirectToAction("Dashboard");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Something went wrong: " + ex.Message;
                }
            }

            return View(product);
        }

        // Logs the user out
        [HttpPost]
        public IActionResult Logout()
        {
            TempData.Clear();
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
