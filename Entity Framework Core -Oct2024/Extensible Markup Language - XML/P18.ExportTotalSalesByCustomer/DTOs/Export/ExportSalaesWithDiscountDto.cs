using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
	[XmlType("sale")]
	public class ExportSalaesWithDiscountDto
	{
		[XmlElement("car")]
		public ExportCarDto Car { get; set; } = null!;

		[XmlElement("discount")]
		public string Discount { get; set; } = null!;

		[XmlElement("customer-name")]
		public string Name { get; set; } = null!;

        [XmlElement("price")]
        public string Price { get; set; } = null!;

		[XmlElement("price-with-discount")]
        public string DiscountedPrice { get; set; } = null!;
	}
}
