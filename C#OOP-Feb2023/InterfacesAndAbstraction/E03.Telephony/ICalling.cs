using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace E03.Telephony
{
    public interface ICalling
    {
        public string PhoneNumber { get; set; }

        public void Calling(string phoneNumber);
    }
}
