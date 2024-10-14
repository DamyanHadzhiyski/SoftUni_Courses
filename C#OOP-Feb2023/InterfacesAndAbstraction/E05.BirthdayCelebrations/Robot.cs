using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E05.BirthdayCelebrations
{
    public class Robot : IIdentifiable
    {
        private string id;

        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model { get; set; }
        public string Id { get => id; set => id = value; }

        public bool IsFake(string lastDigits)
        {
            return this.id.EndsWith(lastDigits);
        }
    }
}
