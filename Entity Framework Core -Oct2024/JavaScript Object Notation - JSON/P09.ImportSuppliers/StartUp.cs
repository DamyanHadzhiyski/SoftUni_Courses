using CarDealer.Data;
using CarDealer.Models;
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

            // 01. Import suppliers
            Console.WriteLine(ImportSuppliers(carDb, suppliersImport));

            // 02. Import parts
            //Console.WriteLine(ImportSuppliers(carDb, partsImport));

            // 03. Import cars
            //Console.WriteLine(ImportSuppliers(carDb, carsImport));

            // 04. Import customers
            //Console.WriteLine(ImportSuppliers(carDb, customersImport));
        }

        #region Imports
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }


        #endregion
    }
}