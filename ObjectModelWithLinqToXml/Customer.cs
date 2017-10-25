using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ObjectModelWithLinqToXml
{
    public class Customer
    {
        public XAttribute CustomerID;

        public XElement CompanyName;

        public XElement ContactName;

        public XElement ContactTitle;

        public XElement Phone;

        public XElement Address;

        public XElement City;

        public XElement Region;

        public XElement PostalCode;

        public XElement Country;

        public List<string> customers = new List<string>();

        public List<string> ShowAllInfoAboutCustomers(string path)
        {
            XDocument xDoc = XDocument.Load(@path);
            XNamespace ns = "http://www.adventure-works.com";

            foreach (XElement customerElement in xDoc.Root.Element(ns + "Customers").Elements(ns + "Customer"))
            {
                CustomerID = customerElement.Attribute("CustomerID");
                CompanyName = customerElement.Element(ns + "CompanyName");
                ContactName = customerElement.Element(ns + "ContactName");
                ContactTitle = customerElement.Element(ns + "ContactTitle");
                Phone = customerElement.Element(ns + "Phone");

                if (CustomerID != null && CompanyName != null && ContactName != null
                    && ContactTitle != null && Phone != null)
                {
                    customers.Add((string)CustomerID.Value);
                    customers.Add((string)CompanyName.Value);
                    customers.Add((string)ContactName.Value);
                    customers.Add((string)ContactTitle.Value);
                    customers.Add((string)Phone.Value);

                }
                foreach (XElement fullAdress in xDoc.Root.Element(ns + "Customers").Element(ns + "Customer").Elements(ns + "FullAddress"))
                {
                    Address = fullAdress.Element(ns + "Address");
                    City = fullAdress.Element(ns + "City");
                    Region = fullAdress.Element(ns + "Region");
                    PostalCode = fullAdress.Element(ns + "PostalCode");
                    Country = fullAdress.Element(ns + "Country");

                    if (Address != null && City != null && Region != null && PostalCode != null && Country != null)
                    {
                        customers.Add("Full Address:");
                        customers.Add("\t" + (string)Address.Value);
                        customers.Add("\t" + (string)City.Value);
                        customers.Add("\t" + (string)Region.Value);
                        customers.Add("\t" + (string)PostalCode.Value);
                        customers.Add("\t" + (string)Country.Value);
                    }
                }
            }
            return customers;
        }

        public IEnumerable<XElement> ShowCustomersByID(XDocument xDoc, string customerId)
        {
            XNamespace ns = "http://www.adventure-works.com";

            var queryByID = from res in xDoc.Root.Element(ns + "Customers").Elements(ns + "Customer")
                        where (string)res.Attribute("CustomerID") == customerId
                        select res;
            return queryByID;
        }

        public IEnumerable<XElement> ShowCustomersByPhone(XDocument xDoc, string phone)
        {
            XNamespace ns = "http://www.adventure-works.com";
            var queryByPhone = from res in xDoc.Root.Element(ns + "Customers").Elements(ns + "Customer")
                        where (string)res.Element(ns+"Phone") == phone
                        select res;

            return queryByPhone;
        }

        public IEnumerable<XElement> ShowAllCustomers(XDocument xDoc)
        {
            XNamespace ns = "http://www.adventure-works.com";
            var queryAll = from res in xDoc.Root.Elements(ns + "Customers")
                        select res;

            return queryAll;
        }
    }
}
