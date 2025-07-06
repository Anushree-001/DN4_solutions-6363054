using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RetailInventoryApp.Models;
using RetailInventoryApp;

namespace RetailInventoryApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new AppDbContext();
            await context.Database.EnsureCreatedAsync();

            // ✅ Lab 4: Insert data only if categories do not exist
            if (!await context.Categories.AnyAsync())
            {
                var books = new Category { Name = "Books" };
                var furniture = new Category { Name = "Furniture" };

                await context.Categories.AddRangeAsync(books, furniture);
                await context.SaveChangesAsync();

                var product1 = new Product { Name = "C# Programming Guide", Price = 1500, Category = books };
                var product2 = new Product { Name = "Office Chair", Price = 8500, Category = furniture };

                await context.Products.AddRangeAsync(product1, product2);
                await context.SaveChangesAsync();

                Console.WriteLine("\nInserted Products:");
                Console.WriteLine($"{product1.Name} - ₹{product1.Price} ({books.Name})");
                Console.WriteLine($"{product2.Name} - ₹{product2.Price} ({furniture.Name})");
            }

            // 🔍 Lab 5: Retrieve data
            var products = await context.Products.Include(p => p.Category).ToListAsync();
            Console.WriteLine("\nAll Products:");
            foreach (var p in products)
                Console.WriteLine($"{p.Name} - ₹{p.Price} ({p.Category.Name})");

            var productFound = await context.Products.FindAsync(1);
            Console.WriteLine($"\nFound: {productFound?.Name}");

            var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 5000);
            Console.WriteLine($"Expensive: {expensive?.Name}");
        }
    }
}

