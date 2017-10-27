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
            
            //order.

            ShipInfo info = new ShipInfo();
            //info.ShipVia = (int)Xdoc.Root.Element(Paths.ns + "Orders").Element(Paths.ns + "Order").Element(Paths.ns + "ShippedDate");
        }

        public List<Order> GetOrders()
        {
            var orders = new List<Order>();
            foreach (var value in Xdoc.Root.Element(Paths.ns + "Orders").Elements(Paths.ns + "Order"))
            {

                var order = new Order();
                order.CustomerID = (string)value.Element(Paths.ns + "CustomerID");
                order.EmployeeID = (string)value.Element(Paths.ns + "EmployeeID");
                order.OrderDate = (DateTime)value.Element(Paths.ns + "OrderDate");
                order.RequiredDate = (DateTime)value.Element(Paths.ns + "RequiredDate");
                var shipInfos = new ShipInfo();
                foreach (var res in value.Elements(Paths.ns + "ShipInfo"))
                {
                    if (value.Attribute("ShippedDate") != null)
                        shipInfos.ShippedDate = (DateTime)res.Attribute("ShippedDate");
                    else shipInfos.ShippedDate = order.RequiredDate;
                    shipInfos.ShipVia = (int)res.Element(Paths.ns + "ShipVia");
                    shipInfos.Freight = (double)res.Element(Paths.ns + "Freight");
                    shipInfos.ShipName = (string)res.Element(Paths.ns + "ShipName");
                    shipInfos.ShipAddress = (string)res.Element(Paths.ns + "ShipAddress");
                    shipInfos.ShipCity = (string)res.Element(Paths.ns + "ShipCity");
                    shipInfos.ShipRegion = (string)res.Element(Paths.ns + "ShipRegion");
                    shipInfos.ShipPostalCode = (int)res.Element(Paths.ns + "ShipPostalCode");
                    shipInfos.ShipCountry = (string)res.Element(Paths.ns + "ShipCountry");
                }
                order.InfoShip = shipInfos;

                orders.Add(order);
            }
            return orders;
        }

        public List<Customer> GetCustomers()
        {
            var customers = new List<Customer>();
            foreach (var value in Xdoc.Root.Element(Paths.ns + "Customers").Elements(Paths.ns + "Customer"))
            {
                var customer = new Customer();
                customer.CustomerID = (string)value.Attribute( "CustomerID");
                customer.CompanyName = (string)value.Element(Paths.ns + "CompanyName");
                customer.ContactName = (string)value.Element(Paths.ns + "ContactName");
                customer.ContactTitle = (string)value.Element(Paths.ns + "ContactTitle");
                customer.Phone = (string)value.Element(Paths.ns + "Phone");
                var fullAddresss = new FullAddress();
                foreach (var res in value.Elements(Paths.ns + "FullAddress"))
                {
                    fullAddresss.Address = (string)res.Element(Paths.ns + "Address");
                    fullAddresss.City = (string)res.Element(Paths.ns + "City");
                    fullAddresss.Region = (string)res.Element(Paths.ns + "Region");
                    fullAddresss.PostalCode = (int)res.Element(Paths.ns + "PostalCode");
                    fullAddresss.Country = (string)res.Element(Paths.ns + "Country");
                }
                customer.FullAddress = fullAddresss;
                customers.Add(customer);
            }
            return customers;
        }


    }
}
