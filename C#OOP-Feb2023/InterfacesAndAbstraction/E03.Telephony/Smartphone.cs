using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E03.Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {
        private string phoneNumber;
        private string webPage;

        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string WebPage { get => webPage; set => webPage = value; }

        public void Calling(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }

        public void Browsing(string page)
        {
            Console.WriteLine($"Browsing: {page}!");
        }
    }
}
