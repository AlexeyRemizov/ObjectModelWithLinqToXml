using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ObjectModelWithLinqToXml
{
    public class Order
    {
        public string CustomerID;

        public string EmployeeID;

        public string OrderDate;

        public string RequiredDate;

        public string ShippedDate;

        public string ShipVia;

        public string Freight;

        public string ShipName;

        public string ShipAddress;

        public string ShipCity;

        public string ShipRegion;

        public string ShipPostalCode;

        public string ShipCountry;

        public IEnumerable<XElement> ShowAllOrdersByCustomer(XDocument xDoc, string customer)
        {
            XNamespace ns = "http://www.adventure-works.com";
            var queryOrdersByCustomerID = from res in xDoc.Root.Element(ns + "Orders").Elements(ns+"Order")
                           where (string)res.Element(ns+"CustomerID") == customer
                           select res;

            return queryOrdersByCustomerID;
        }
    }
}
