using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E05.BirthdayCelebrations
{
    public interface IIdentifiable
    {
        public string Id { get; set; }

        public bool IsFake(string lastDigits);
    }
}
