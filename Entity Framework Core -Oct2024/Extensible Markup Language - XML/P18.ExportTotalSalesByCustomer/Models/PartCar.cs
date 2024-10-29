using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealer.Models
{
    public class PartCar
    {
        [Required]
        public int PartId { get; set; }

        [ForeignKey(nameof(PartId))]
        public Part Part { get; set; } = null!;

        [Required]
        public int CarId { get; set; }
        [ForeignKey(nameof(CarId))] 
        public Car Car { get; set; } = null!; 
    }
}
