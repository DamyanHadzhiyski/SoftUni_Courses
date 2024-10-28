using CarDealer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DTOs.Import
{
    public class CarPartsDTO
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int TraveledDistance { get; set; }

        [JsonProperty("partsId")]
        public ICollection<int> PartsIds { get; set; }
    }
}
