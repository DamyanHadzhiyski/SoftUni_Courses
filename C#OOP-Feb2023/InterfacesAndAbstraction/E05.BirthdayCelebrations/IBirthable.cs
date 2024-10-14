using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E05.BirthdayCelebrations
{
    public interface IBirthable
    {
        public string Birthdate { get; set; }

        public bool BirthYearMatch(string year);
    }
}
