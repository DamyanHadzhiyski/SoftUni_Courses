﻿using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
	[XmlType("sale")]
	public class ExportSalaesWithDiscountDto
	{
		[XmlElement("car")]
		public ExportCarDto Car { get; set; } = null!;

        [XmlElement("discount")]
        public decimal Discount { get; set; }

		[XmlElement("customer-name")]
		public string Name { get; set; } = null!;

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("price-with-discount")]
        public decimal DiscountedPrice { get; set; }
    }
}
