using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using System.Xml;

namespace ObjectModelWithLinqToXml
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var curFilePath = ConfigurationManager.AppSettings[@"Path"];
            var filePath = (Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory))+curFilePath;

            XDocument xDoc = XDocument.Load(@filePath);

            var customersInfo = new Customer();
            var results = customersInfo.ShowAllInfoAboutCustomers(filePath);
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }

            var custs = customersInfo.ShowCustomersByID(xDoc, "GREAL");
            foreach (var cuat in custs)
            {
                Console.WriteLine((string)cuat.Value);
            }

            var phones = customersInfo.ShowCustomersByPhone(xDoc, "(415) 555-5938");
            foreach (var phone in phones)
            {
                Console.WriteLine((string)phone.Value);
            }


            var showAll = customersInfo.ShowAllCustomers(xDoc);
            foreach (var show in showAll)
            {
                Console.WriteLine("New item: {0}",(string)show.Value);
            }

            Order orders = new Order();
            var showOrdersByCustomerID = orders.ShowAllOrdersByCustomer(xDoc, "GREAL");
            foreach (var showOrders in showOrdersByCustomerID)
            {
                Console.WriteLine("Order: {0}", (string)showOrders.Value);
            }

            Console.ReadKey();

        }
    }
    
}
