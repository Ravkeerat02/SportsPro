

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GBC.Models;
using System;
using System.Linq;
using GBC.Data;

namespace GBC.Models
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GBCContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<GBCContext>>()))
            {
                // Look for any products.
                if (context.ProductManager.Any())
                {
                    return;   // DB has been seeded
                }
                context.ProductManager.AddRange(
                    new ProductManager
                    {
                        //Id = 10
                        ProductCode = "TRNY10",
                        ProductName = "Tournament Master 1.0",
                        Price = 4.99M,
                        ReleaseDate = DateTime.Parse("2015-01-12")
                    },

                    new ProductManager
                    {
                        //Id = 11,
                        ProductCode = "LEAG10",
                        ProductName = "League Scheduler 1.0",
                        Price = 4.99M,
                        ReleaseDate = DateTime.Parse("2016-01-05")
                    },

                    new ProductManager
                    {
                        //Id = 12,
                        ProductCode = "LEAGD10",
                        ProductName = "League Scheduler Deluxe 1.0",
                        Price = 7.99M,
                        ReleaseDate = DateTime.Parse("2016-01-08")
                    },

                    new ProductManager
                    {
                        //Id = 13,
                        ProductCode = "DRAFT10",
                        ProductName = "Draft Manager 1.0",
                        Price = 4.99M,
                        ReleaseDate = DateTime.Parse("2017-01-02")
                    }
                );
                context.SaveChanges();



                // Look for any products.
                if (context.TechManager.Any())
                {
                    return;   // DB has been seeded
                }
                context.TechManager.AddRange(
                    new TechManager
                    {
                        //Id = 10
                        TechName = "Mark Sloan",
                        TechEmail = "mark@sportsapplication.com",
                        TechPhone = "6478569854"

                    },

                    new TechManager
                    {
                        TechName = "Kendrick Lamar",
                        TechEmail = "kendrick@lamar.com",
                        TechPhone = "6478546527"
                    }
                );
                context.SaveChanges();


                // Look for any products.
                if (context.CustomerManager.Any())
                {
                    return;   // DB has been seeded
                }
                context.CustomerManager.AddRange(
                    new CustomerManager
                    {

                        CustomerName = "Dan Fresh",
                        CustomerAddress = "50 Charming Ave",
                        CustomerCity = "Toronto",
                        CustomerState = "ON",
                        CustomerPostal = "M2K 2K2",
                        Country = CustomerManager.CustomerCountry.Canada,
                        CustomerEmail = "dan@fresh.com",
                        CustomerPhone = "6477853658"

                    },

                    new CustomerManager
                    {
                        CustomerName = "Jane Miller",
                        CustomerAddress = "123 Keyboard Lane",
                        CustomerCity = "New York City",
                        CustomerState = "New York",
                        CustomerPostal = "00000",
                        Country = CustomerManager.CustomerCountry.USA,
                        CustomerEmail = "jane@miller.com",
                        CustomerPhone = "6477657432"
                    }
                );
                context.SaveChanges();


                // Look for any products.
                if (context.IncidentPage.Any())
                {
                    return;   // DB has been seeded
                }
                context.IncidentPage.AddRange(
                    new IncidentPage
                    {
                        //Id = 10
                        Product = "Fifa",
                        Title = "Broken",
                        Description = "no messi",
                        TechName = "Mark Sloan",
                        DateOpened = DateTime.Parse("2015-01-12"),
                        DateClosed = DateTime.Parse("2015-12-12"),

                    },

                    new IncidentPage
                    {
                        Product = "LEAG10",
                        Title = "White Screen",
                        Description = "White screen occurs when opening the product and nothing happens.",
                        TechName = "Kendrick Lamar",
                        DateOpened = DateTime.Parse("2015-01-12"),
                        DateClosed = DateTime.Parse("2015-12-12"),
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

