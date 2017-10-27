using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ObjectMode.XMLDAL;

namespace ObjectModel
{
    public class BusinessLogic
    {
        DAL dataAccessLayer = new DAL(Paths.XDoc);

        public List<Order> ShowAllOrders()
        {
            var AllOrders = dataAccessLayer.GetOrders();
            List<Order> ordersBL = new List<Order>();
            foreach (var item in AllOrders)
            {
                var orderBL = new Order();
                orderBL.CustomerID = (item.CustomerID);
                orderBL.EmployeeID = (item.EmployeeID);
                orderBL.OrderDate = (item.OrderDate);
                orderBL.RequiredDate = (item.RequiredDate);
                orderBL.InfoShip = (item.InfoShip);
                //orderBL.InfoShip.ShipVia = (item.InfoShip.ShipVia);
                //orderBL.InfoShip.Freight = (item.InfoShip.Freight);
                //orderBL.InfoShip.ShipName = (item.InfoShip.ShipName);
                //orderBL.InfoShip.ShipAddress = (item.InfoShip.ShipAddress);
                //orderBL.InfoShip.ShipCity = (item.InfoShip.ShipCity);
                //orderBL.InfoShip.ShipRegion = (item.InfoShip.ShipRegion);
                //orderBL.InfoShip.ShipPostalCode = (item.InfoShip.ShipPostalCode);
                //orderBL.InfoShip.ShipCountry = (item.InfoShip.ShipCountry);
                ordersBL.Add(orderBL);
                //Console.WriteLine(ordero.CustomerID);
            }
            return ordersBL;
        }

        public List<Customer> ShowAllCustomers()
        {
            var allCustomers = dataAccessLayer.GetCustomers();
            
            List<Customer> customersBL = new List<Customer>();
            foreach (var item in allCustomers)
            {
                var customerBL = new Customer();
                customerBL.CustomerID = (item.CustomerID);
                customerBL.CompanyName = (item.CompanyName);
                customerBL.ContactName = (item.ContactName);
                customerBL.ContactTitle = (item.ContactTitle);
                customerBL.FullAddress = (item.FullAddress);
                customersBL.Add(customerBL);
            }
            return customersBL;
        }

        public IEnumerable<Order> ShowByCustomerIDOnOrders()
        {
            var allCustomers = dataAccessLayer.GetOrders();
            var queryByCustomerOnOrders = from q in allCustomers
                        where q.CustomerID == "LETSS"
                        select q;

            return queryByCustomerOnOrders;
        }

        public IEnumerable<Customer> ShowByCustomerIDOnCustomers()
        {
            var allCustomers = dataAccessLayer.GetCustomers();
            var queryByCustomerOnCustomers = from q in allCustomers
                                          where q.CustomerID == "HUNGC"
                                          select q;

            return queryByCustomerOnCustomers;
        }

        public IEnumerable<Order> ShowSortedOrdersByEmployeeID()
        {
            var allOrders = dataAccessLayer.GetOrders();
            var querySortedOrders = from item in allOrders
                                    orderby item.EmployeeID, item.OrderDate
                                    select item;

            return querySortedOrders;
        }
    }
}
