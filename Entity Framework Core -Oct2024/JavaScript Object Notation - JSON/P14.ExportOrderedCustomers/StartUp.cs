using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
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
            Console.WriteLine(GetOrderedCustomers(carDb));

            // 15. Export Cars from Make Toyota
            //Console.WriteLine(GetCarsFromMakeToyota(carDb));

            // 16. Export Local Suppliers
            //Console.WriteLine(GetLocalSuppliers(carDb));

            // 17. Export Cars with Their List of Parts
            //Console.WriteLine(GetCarsWithTheirListOfParts(carDb));

            // 18. Export Total Sales by Customer
            //Console.WriteLine(GetTotalSalesByCustomer(carDb));

            // 19. Export Sales with Applied Discount
            //Console.WriteLine(GetSalesWithAppliedDiscount(carDb));
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

        #endregion
    }
}