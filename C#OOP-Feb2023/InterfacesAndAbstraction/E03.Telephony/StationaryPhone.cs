using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E03.Telephony
{
    public class StationaryPhone : ICalling
    {
        private string phoneNumber;

        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        public void Calling(string number)
        {
            Console.WriteLine($"Dialing... {number}"); ;
        }
    }
}
