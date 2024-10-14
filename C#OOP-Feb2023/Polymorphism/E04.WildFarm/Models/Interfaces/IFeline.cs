using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace E04.WildFarm.Models.Interfaces
{
    public interface IFeline : IMammal
    {
        public string Breed { get; }
    }
}
