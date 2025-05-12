using Agri_Energy_Riaan_Carelse_ST10065550_Prog7311_PoePart2.Models;
using System;
using System.Linq;

namespace Agri_Energy_Riaan_Carelse_ST10065550_Prog7311_PoePart2
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.EnsureCreated();

            // Seed Farmers
            if (!context.Farmers.Any())
            {
                context.Farmers.AddRange(
                    new Farmer { FarmerId = 1, FirstName = "John", LastName = "Doe", Password = "1234", ContactNumber = "1234567893" , Email = "john@farm.com" },
                    new Farmer { FarmerId = 2, FirstName = "Anna", LastName = "Smith", Password = "pass", ContactNumber = "9876543210" , Email = "anna@farm.com" }
                );
                context.SaveChanges(); // Save now so FarmerIds are available
            }

            // Seed Employees
            if (!context.Employees.Any())
            {
                context.Employees.AddRange(
                    new Employee { FirstName = "Emily", LastName = "Jones", Password = "admin", Email = "emily@agri.com" },
                    new Employee { FirstName = "David", LastName = "Clark", Password = "admin123", Email = "david@agri.com" }
                );
            }

            // Seed Products
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Organic Maize",
                        Category = "Grain",
                        ProductionDate = DateTime.Now.AddDays(-30),
                        FarmerId = 1
                    },
                    new Product
                    {
                        Name = "Sunflower Oil",
                        Category = "Oil",
                        ProductionDate = DateTime.Now.AddDays(-10),
                        FarmerId = 1
                    },
                    new Product
                    {
                        Name = "Free-Range Eggs",
                        Category = "Livestock",
                        ProductionDate = DateTime.Now.AddDays(-7),
                        FarmerId = 2
                    },
                    new Product
                    {
                        Name = "Tomatoes",
                        Category = "Vegetable",
                        ProductionDate = DateTime.Now.AddDays(-3),
                        FarmerId = 2
                    }
                );
            }

            context.SaveChanges();
        }
    }
}
