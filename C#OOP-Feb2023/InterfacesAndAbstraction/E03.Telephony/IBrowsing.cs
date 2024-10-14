using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E03.Telephony
{
    public interface IBrowsing
    {
        public string WebPage { get; set; }

        public void Browsing(string page);
    }
}
