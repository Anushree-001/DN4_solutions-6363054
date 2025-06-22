// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public string Name { get; set; }

    public Product(string name)
    {
        Name = name;
    }
}

public class ECommerceSearch
{
    public static List<Product> Search(List<Product> products, string keyword)
    {
        return products
            .Where(p => p.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>
        {
            new Product("Apple iPhone 14"),
            new Product("Samsung Galaxy S24"),
            new Product("Apple MacBook Pro"),
            new Product("Sony Headphones"),
            new Product("Dell XPS Laptop")
        };

        Console.Write("Enter keyword to search: ");
        string? input = Console.ReadLine();
        string keyword = input ?? "";

        var results = ECommerceSearch.Search(products, keyword);

        if (results.Count == 0)
        {
            Console.WriteLine("No products found.");
        }
        else
        {
            Console.WriteLine("Matching Products:");
            foreach (var product in results)
            {
                Console.WriteLine($"- {product.Name}");
            }
        }
    }
}

