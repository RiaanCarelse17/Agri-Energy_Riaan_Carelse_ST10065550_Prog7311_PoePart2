using Agri_Energy_Riaan_Carelse_ST10065550_Prog7311_PoePart2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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

        // Displays the Farmer Dashboard
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }

        // Displays the AddProduct page (GET)
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View(new Product());
        }

        // Adds a product to the database (POST)
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Assuming the FarmerId is stored in session or context
                    // In a real app, you'd retrieve the logged-in farmer's ID
                    product.FarmerId = 1; // Replace with actual logged-in farmer ID, if necessary

                    // Ensuring the date is stored correctly
                    product.ProductionDate = product.ProductionDate.Date;

                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();

                    // Success message for product addition
                    ViewBag.Success = "Product added successfully!";
                    ModelState.Clear(); // Clear the form fields after successful submission
                    return RedirectToAction("Dashboard"); // Redirect to Dashboard
                }
                catch (Exception ex)
                {
                    // Error handling
                    ViewBag.Error = "Something went wrong: " + ex.Message;
                }
            }
            return View(); // In case of error, return to the AddProduct page
        }

        // Logs out the user and redirects to the home page
        [HttpPost]
        public IActionResult Logout()
        {
            // You can add session clearing or authentication sign-out logic here if necessary
            return RedirectToAction("Index", "Home");
        }
    }
}
