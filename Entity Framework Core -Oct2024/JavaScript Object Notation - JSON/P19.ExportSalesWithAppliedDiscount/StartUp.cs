using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using System.Globalization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            //DB instance
            CarDealerContext carDb = new CarDealerContext();

            //Import file locations
            string suppliersImport = File.ReadAllText(@"../../../Datasets/suppliers.json");
            string partsImport = File.ReadAllText(@"../../../Datasets/parts.json");
            string carsImport = File.ReadAllText(@"../../../Datasets/cars.json");
            string customersImport = File.ReadAllText(@"../../../Datasets/customers.json");
            string salesImport = File.ReadAllText(@"../../../Datasets/sales.json");

            // 09. Import suppliers
            //Console.WriteLine(ImportSuppliers(carDb, suppliersImport));

            // 10. Import parts
            //Console.WriteLine(ImportParts(carDb, partsImport));

            // 11. Import cars
            //Console.WriteLine(ImportCars(carDb, carsImport));

            // 11.1. Import parts cars
            //ImportPartsCars(carDb, carsImport);

            // 12. Import customers
            //Console.WriteLine(ImportCustomers(carDb, customersImport));

            // 13. Import sales
            //Console.WriteLine(ImportSales(carDb, salesImport));

            // 14. Export Ordered Customers
            //Console.WriteLine(GetOrderedCustomers(carDb));

            // 15. Export Cars from Make Toyota
            //Console.WriteLine(GetCarsFromMakeToyota(carDb));

            // 16. Export Local Suppliers
            //Console.WriteLine(GetLocalSuppliers(carDb));

            // 17. Export Cars with Their List of Parts
            //Console.WriteLine(GetCarsWithTheirListOfParts(carDb));

            // 18. Export Total Sales by Customer
            //Console.WriteLine(GetTotalSalesByCustomer(carDb));

            // 19. Export Sales with Applied Discount
            Console.WriteLine(GetSalesWithAppliedDiscount(carDb));
        }

        #region Imports
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert
                .DeserializeObject<List<Part>>(inputJson);

            int counter = 0;

            foreach (var part in parts)
            {
                if (context.Suppliers.Select(s => s.Id).Contains(part.SupplierId))
                {
                    context.Parts.Add(part);
                    counter++;
                }
            }

            context.SaveChanges();

            return $"Successfully imported {counter}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<List<Car>>(inputJson);

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        private static void ImportPartsCars(CarDealerContext context, string inputJson)
        {
            var carParts = JsonConvert.DeserializeObject<List<CarPartsDTO>>(inputJson);

            var parts = context.Parts
                        .Select(p => p.Id)
                        .ToList();

            int counter = 0;

            foreach (var part in parts)
            {
                int carId = 0;
                foreach (var car in carParts)
                {
                    carId++;
                    if (car.PartsIds.Contains(part))
                    {
                        PartCar partCar = new PartCar
                        {
                            PartId = part,
                            CarId = carId
                        };
                        context.PartsCars.Add(partCar);
                        counter++;
                    }
                }
            }

            context.SaveChanges();

            //return $"Successfully imported {counter}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }
        #endregion

        #region Exports
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                            .Select(c => new
                            {
                                c.Name,
                                c.BirthDate,
                                c.IsYoungDriver,
                            })
                            .OrderBy(c => c.BirthDate)
                            .ThenBy(c => c.IsYoungDriver)
                            .ToList();

            return JsonConvert.SerializeObject(customers
                                                .Select(c => new
                                                {
                                                    Name = c.Name,
                                                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                                                    IsYoungDriver = c.IsYoungDriver
                                                }),
                                                Formatting.Indented);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                             .Where(c => c.Make == "Toyota")
                             .Select(c => new
                             {
                                 c.Id,
                                 c.Make,
                                 c.Model,
                                 c.TraveledDistance
                             })
                             .OrderBy(c => c.Model)
                             .ThenByDescending(c => c.TraveledDistance)
                             .ToList();

            return JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                                        .Where(s => s.IsImporter == false)
                                        .Select(s => new
                                        {
                                            s.Id,
                                            s.Name,
                                            PartsCount = s.Parts.Count()
                                        })
                                        .ToList();

            return JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carWithParts = context.Cars
                                      .Select(pc => new
                                      {
                                          car = new
                                          {
                                              pc.Make,
                                              pc.Model,
                                              pc.TraveledDistance
                                          },
                                          parts = pc.PartsCars
                                                   .Select(pc => new
                                                   {
                                                       Name = pc.Part.Name,
                                                       Price = pc.Part.Price.ToString("f2")
                                                   })
                                                   .ToList()
                                      })
                                      .ToList();

            return JsonConvert.SerializeObject(carWithParts, Formatting.Indented);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customerCars = context.Customers
                                .Include(c => c.Sales)
                                .ThenInclude(s => s.Car.PartsCars)
                                .ThenInclude(pc => pc.Part)
                                .Where(c => c.Sales.Any())
                                .ToArray()
                                .Select(c => new
                                {
                                    fullName = c.Name,
                                    boughtCars = c.Sales.Count,
                                    spentMoney = c.Sales.Sum(s => s.Car.PartsCars.Sum(p => p.Part.Price))
                                })
                                .OrderByDescending(c => c.spentMoney)
                                .ThenByDescending(c => c.boughtCars);


            return JsonConvert.SerializeObject(customerCars, Formatting.Indented);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                        .Select(s => new
                        {
                            car = new
                            {
                                Make = s.Car.Make,
                                Model = s.Car.Model,
                                TraveledDistance = s.Car.TraveledDistance
                            },
                            customerName = s.Customer.Name,
                            discount = s.Discount.ToString("f2"),
                            price = s.Car.PartsCars.Sum(pc => pc.Part.Price).ToString("f2"),
                            priceWithDiscount = (s.Car.PartsCars.Sum(pc => pc.Part.Price) *(1 - (s.Discount / 100m))).ToString("f2")
                        })
                        .Take(10)
                        .ToList();

            return JsonConvert.SerializeObject(sales);
        }
        #endregion
    }
}