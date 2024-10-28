using CarDealer.Data;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
            Console.WriteLine(ImportParts(carDb, partsImport));

            // 11. Import cars
            //Console.WriteLine(ImportCars(carDb, carsImport));

            // 12. Import customers
            //Console.WriteLine(ImportCustomers(carDb, customersImport));

            // 13. Import sales
            //Console.WriteLine(ImportSales(carDb, salesImport));
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
        #endregion
    }
}