using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("Product")]
    public class ExportProductRangeDTO
    {
        [XmlElement("name")]
        public string ProductName { get; set; }
        [XmlElement("price")]
        public decimal ProductPrice { get; set; }
        [XmlElement("buyer")]
        public string BuyerName { get; set; }
    }
}
