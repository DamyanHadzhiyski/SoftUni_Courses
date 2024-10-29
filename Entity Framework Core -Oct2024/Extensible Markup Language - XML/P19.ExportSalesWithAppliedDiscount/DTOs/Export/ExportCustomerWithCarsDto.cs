using CarDealer.Models;

namespace CarDealer.DTOs.Export
{
	public class ExportCustomerWithCarsDto
	{
		public string Name { get; set; } = null!;

		public ICollection<Car> Cars { get; set; } = null!;
	}
}
