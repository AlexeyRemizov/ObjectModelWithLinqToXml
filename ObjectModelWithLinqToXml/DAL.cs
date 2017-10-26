using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectModel;
using System.Xml.Linq;

namespace ObjectMode.XMLDAL
{
    public class DAL
    {
        public XDocument Xdoc;

        public DAL(XDocument xdocument)
        {
            Xdoc = xdocument;
            Order order = new Order();
            order.CustomerID = (string)Xdoc.Root.Element(Paths.ns + "Orders").Element(Paths.ns + "Order").Element(Paths.ns + "CustomerID");
            order.EmployeeID = (string)Xdoc.Root.Element(Paths.ns + "Orders").Element(Paths.ns + "Order").Element(Paths.ns + "EmployeeID");
            order.OrderDate = (DateTime)Xdoc.Root.Element(Paths.ns + "Orders").Element(Paths.ns + "Order").Element(Paths.ns + "OrderDate");
            order.RequiredDate = (DateTime)Xdoc.Root.Element(Paths.ns + "Orders").Element(Paths.ns + "Order").Element(Paths.ns + "RequiredDate");
            order.ShippedDate = (DateTime)Xdoc.Root.Element(Paths.ns + "Orders").Element(Paths.ns + "Order").Element(Paths.ns + "ShippedDate");

            ShipInfo info = new ShipInfo();
            //info.ShipVia = (int)Xdoc.Root.Element(Paths.ns + "Orders").Element(Paths.ns + "Order").Element(Paths.ns + "ShippedDate");
        }

        public List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();
            foreach (var p in )
            {
                orders.Add(new Order());
            }

            for()
            {
                new Customer;

            }
            return orders;
        }

    }
}
