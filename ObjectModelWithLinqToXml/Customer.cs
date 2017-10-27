using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ObjectModel
{
    public class Customer
    {
        public string CustomerID;

        public string CompanyName;

        public string ContactName;

        public string ContactTitle;

        public string Phone;
        
        public FullAddress FullAddress;
    }
}
