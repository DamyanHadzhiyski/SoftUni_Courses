using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            //Database context
            CarDealerContext carDb = new CarDealerContext();

            //Import paths
            string suppliersXml = File.ReadAllText(@"../../../Datasets/suppliers.xml");
            string partsXml = File.ReadAllText(@"../../../Datasets/parts.xml");
            string carsXml = File.ReadAllText(@"../../../Datasets/cars.xml");
            string customersXml = File.ReadAllText(@"../../../Datasets/customers.xml");
            string salesXml = File.ReadAllText(@"../../../Datasets/sales.xml");

            #region Import Calls
            // 09. Import suppliers
            //Console.WriteLine(ImportSuppliers(carDb, suppliersXml));

            // 10. Import parts
            //Console.WriteLine(ImportParts(carDb, partsXml));

            // 11. Import cars
            //Console.WriteLine(ImportCars(carDb, carsXml));

            // 12. Import customers
            //Console.WriteLine(ImportCustomers(carDb, customersXml));

            // 13. Import sales
            //Console.WriteLine(ImportSales(carDb, salesXml));
            #endregion

            #region Export Calls
            // 14. Export Cars With Distance
            //Console.WriteLine(GetCarsWithDistance(carDb));

            // 15. Export Cars With Distance
            //Console.WriteLine(GetCarsFromMakeBmw(carDb));

            // 16. Export Cars With Distance
            //Console.WriteLine(GetLocalSuppliers(carDb));

            // 17. Export Cars With Distance
            //Console.WriteLine(GetCarsWithTheirListOfParts(carDb));

            // 18. Export Cars With Distance
            //Console.WriteLine(GetTotalSalesByCustomer(carDb));

            // 19. Export Cars With Distance
            //Console.WriteLine(GetSalesWithAppliedDiscount(carDb));
            #endregion
        }

        private static Mapper GetMapper()
        {
            MapperConfiguration cfg = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());

            return new Mapper(cfg);
        }

        #region Imports
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(ImportSuppliersDTO[]), new XmlRootAttribute("Suppliers"));

            ImportSuppliersDTO[] deserialized = (ImportSuppliersDTO[])serializer.Deserialize(new StringReader(inputXml));

            var mapper = GetMapper();

            Supplier[] suppliers = mapper.Map<Supplier[]>(deserialized);

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportPartsDTO[]), new XmlRootAttribute("Parts"));
            ImportPartsDTO[] deserialized = (ImportPartsDTO[])serializer.Deserialize(new StringReader(inputXml));

            int[] suppleirIds = context.Suppliers
                                        .Select(s => s.Id)
                                        .ToArray();

            var mapper = GetMapper();
            Part[] parts = mapper.Map<Part[]>(deserialized)
                                    .Where(p => suppleirIds.Contains(p.SupplierId))
                                    .ToArray();

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportCarsDTO[]), new XmlRootAttribute("Cars"));
            ImportCarsDTO[] deserialized = (ImportCarsDTO[])serializer.Deserialize(new StringReader(inputXml));

            int[] partIds = context.Parts
                                    .Select(p => p.Id)
                                    .ToArray();

            Mapper mapper = GetMapper();
            Car[] cars = mapper.Map<Car[]>(deserialized);

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportCustomersDTO[]), new XmlRootAttribute("Customers"));
            ImportCustomersDTO[] deserialized = (ImportCustomersDTO[])serializer.Deserialize(new StringReader(inputXml));

            Mapper mapper = GetMapper();
            Customer[] customers = mapper.Map<Customer[]>(deserialized);

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportSalesDTO[]), new XmlRootAttribute("Sales"));
            ImportSalesDTO[] deserialized = (ImportSalesDTO[])serializer.Deserialize(new StringReader(inputXml));

            int[] carIds = context.Cars
                                    .Select(c => c.Id)
                                    .ToArray();

            Mapper mapper = GetMapper();
            Sale[] sales = mapper.Map<Sale[]>(deserialized)
                                    .Where(s => carIds.Contains(s.CarId))
                                    .ToArray();

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }
        #endregion

        #region Exports
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                       .Where(c => c.TraveledDistance > 2000000)
                       .Select(c => new ExportCarDistanceDTO
                       {
                           Make = c.Make,
                           Model = c.Model,
                           TraveledDistance = c.TraveledDistance
                       })
                       .OrderBy(c => c.Make)
                       .ThenBy(c => c.Model)
                       .Take(10)
                       .ToArray();

            var serializer = 
                new XmlSerializer(typeof(ExportCarDistanceDTO[]), new XmlRootAttribute("cars"));

            var xns = new XmlSerializerNamespaces();
            xns.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            StringWriter sw = new StringWriter(sb);

            serializer.Serialize(sw, cars, xns);

            return sb.ToString().Trim();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                              .Where(c => c.Make == "BMW")
                              .Select(c => new ExportBMWCarsDTO
                              {
                                  Id = c.Id,
                                  Model = c.Model,
                                  TraveledDistance = c.TraveledDistance
                              })
                              .OrderBy(c => c.Model)
                              .ThenByDescending(c => c.TraveledDistance)
                              .ToArray();

            var serializer =
                new XmlSerializer(typeof(ExportBMWCarsDTO[]), new XmlRootAttribute("cars"));

            var xns = new XmlSerializerNamespaces();
            xns.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            StringWriter sw = new StringWriter(sb);

            serializer.Serialize(sw, cars, xns);

            return sb.ToString().Trim();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                                   .Where(s => !s.IsImporter)
                                   .Select(s => new ExportLocalSuppliersDTO
                                   {
                                       Id = s.Id,
                                       Name = s.Name,
                                       PartsCount = s.Parts.Count
                                   })
                                   .ToArray();

            var serializer =
                new XmlSerializer(typeof(ExportLocalSuppliersDTO[]), new XmlRootAttribute("suppliers"));

            var xns = new XmlSerializerNamespaces();
            xns.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            StringWriter sw = new StringWriter(sb);

            serializer.Serialize(sw, suppliers, xns);

            return sb.ToString().Trim();
        }
        #endregion
    }
};
