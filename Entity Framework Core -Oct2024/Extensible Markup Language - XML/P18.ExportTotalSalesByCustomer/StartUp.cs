using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
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

			// 15. Export Cars From Make BMW
			//Console.WriteLine(GetCarsFromMakeBmw(carDb));

			// 16. Export Local Suppliers
			//Console.WriteLine(GetLocalSuppliers(carDb));

			// 17. Export Cars With Their List Of Parts
			//Console.WriteLine(GetCarsWithTheirListOfParts(carDb));

			// 18. Export Total Sales By Customer
			Console.WriteLine(GetTotalSalesByCustomer(carDb));

			// 19. Export Sales With Applied Discount
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
			
			var partsId = context.Parts
							.Select(p => p.Id)
							.ToArray();

			List<Car> cars = new List<Car>();
			List<PartCar> partsCars = new List<PartCar>();

			foreach (var carDto in deserialized)
			{
				Car car = new Car
				{
					Make = carDto.Make,
					Model = carDto.Model,
					TraveledDistance = carDto.TraveledDistance,
					PartsCars = new List<PartCar>()
				};

				var uniquePartIds = carDto.PartIds.DistinctBy(e => e.PartId).ToArray();

				foreach(var partId in uniquePartIds)
				{
					if(!partsId.Contains(partId.PartId))
					{
						continue;
					}

					PartCar partCar = new PartCar
					{
						Car = car,
						PartId = partId.PartId
					};

					partsCars.Add(partCar);
					car.PartsCars.Add(partCar);
				}

				cars.Add(car);
			}

			context.AddRange(cars);
			context.AddRange(partsCars);
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

		public static string GetCarsWithTheirListOfParts(CarDealerContext context)
		{
			var carsWithParts = context.Cars
									   .Select(c => new ExportCarWithPartsDTO
									   {
										   Make = c.Make,
										   Model = c.Model,
										   TraveledDistance = c.TraveledDistance,
										   Parts = c.PartsCars
													.Select(pc => new ExportPartsDTO
													{
														Name = pc.Part.Name,
														Price = pc.Part.Price
													})
													.OrderByDescending(pc => pc.Price)
													.ToArray()

									   })
									   .OrderByDescending(c => c.TraveledDistance)
									   .ThenBy(c => c.Model)
									   .Take(5)
									   .ToArray();

			var serializer =
				new XmlSerializer(typeof(ExportCarWithPartsDTO[]), new XmlRootAttribute("cars"));

			var xns = new XmlSerializerNamespaces();
			xns.Add(string.Empty, string.Empty);

			StringBuilder sb = new StringBuilder();

			StringWriter sw = new StringWriter(sb);

			serializer.Serialize(sw, carsWithParts, xns);

			return sb.ToString().Trim();
		}

		public static string GetTotalSalesByCustomer(CarDealerContext context)
		{

			var customerWithBoughtCars = context.Customers
								.Include(c => c.Sales)
								.ThenInclude(s => s.Car.PartsCars)
								.ThenInclude(pc => pc.Part)
								.Where(c => c.Sales.Any())
								.ToArray()
								.Select(c => new ExportCustomerTotalSalesDTO
								{
									Name = c.Name,
									BoughtCars = c.Sales.Count,
									SpentMoney = Math.Round((c.IsYoungDriver ? 
													c.Sales.Sum(s => s.Car.PartsCars.Sum(p => p.Part.Price)) * 0.95m :
													c.Sales.Sum(s => s.Car.PartsCars.Sum(p => p.Part.Price))),2, MidpointRounding.ToZero)
								})
								.OrderByDescending(c => c.SpentMoney)
								.ToArray();

			var serializer =
				new XmlSerializer(typeof(ExportCustomerTotalSalesDTO[]), new XmlRootAttribute("customers"));

			var xns = new XmlSerializerNamespaces();
			xns.Add(string.Empty, string.Empty);

			StringBuilder sb = new StringBuilder();

			StringWriter sw = new StringWriter(sb);

			serializer.Serialize(sw, customerWithBoughtCars, xns);

			return sb.ToString().Trim();
		}

		public static string GetSalesWithAppliedDiscount(CarDealerContext context)
		{
			var salesWithDiscount = context.Sales
											.Select(s => new ExportSalaesWithDiscountDto
											{
												Car = new ExportCarDto
												{
													Make = s.Car.Make,
													Model = s.Car.Model,
													TraveledDistance = s.Car.TraveledDistance
												},
												Discount = s.Discount.ToString(),
												Name = s.Customer.Name,
												Price = s.Car.PartsCars.Sum(pc => pc.Part.Price).ToString(),
												DiscountedPrice = (s.Car.PartsCars.Sum(pc => pc.Part.Price) * (1 - s.Discount / 100m)).ToString()
											})
											.ToArray();

			var serializer =
				new XmlSerializer(typeof(ExportSalaesWithDiscountDto[]), new XmlRootAttribute("sales"));

			var xns = new XmlSerializerNamespaces();
			xns.Add(string.Empty, string.Empty);

			StringBuilder sb = new StringBuilder();

			StringWriter sw = new StringWriter(sb);

			serializer.Serialize(sw, salesWithDiscount, xns);

			return sb.ToString().Trim();
		}
		#endregion
	}
};
