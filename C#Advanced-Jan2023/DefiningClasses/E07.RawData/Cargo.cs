using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E07.RawData
{
    public class Cargo
    {
        private string type;
        private int weight;

        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }

        public string Type { get; set; }
        public int Weight { get; set; }

    }
}
