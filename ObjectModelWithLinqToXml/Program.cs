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

            CustomersAndOrders cando = new CustomersAndOrders();

            cando.ReadXml(filePath);
            //cando.Read(filePath);

            Console.ReadKey();
        }
    }

    public class CustomersAndOrders
    {
        public void ReadXml(string curFile)
        {


            XDocument xDoc = XDocument.Load(@curFile);
            //Console.WriteLine(xDoc);
            /*var query = from n in xDoc.Root.Descendants("Customers")
                         where (string)n.Attribute("CustomerID") == "GREAL"
                        select (n.Element("CompanyName").Value +" "
                        +n.Element("ContactName"));
            foreach (var q in query)
            {
                Console.WriteLine("------", q);
            }*/

            var root = xDoc.Root;
            var elem = root.Elements("Customers");
            var elems = root.Elements("Customers").Elements("Customer");


            foreach (XElement customerElement in xDoc.Root.Elements("Root"))
            {
                XAttribute nameAttribute = customerElement.Attribute("CustomerID");
                XElement companyName = customerElement.Element("CompanyName");
                XElement contactName = customerElement.Element("ContactName");
                XElement contactTitle = customerElement.Element("ContactTitle");
                XElement contactPhone = customerElement.Element("Phone");
                XElement fullAdress = customerElement.Element("FullAdress");


                if (nameAttribute != null && companyName != null && contactName != null
                    && contactTitle!=null && contactPhone!= null && fullAdress!= null)
                {
                    Console.WriteLine("CusomerID: {0}", nameAttribute.Value);
                    Console.WriteLine("Company name: {0}", companyName.Value);
                    Console.WriteLine("Contact name: {0}", contactName.Value);
                    Console.WriteLine("Contact title: {0}", contactTitle.Value);
                    Console.WriteLine("Contact fhone: {0}", contactPhone.Value);
                    Console.WriteLine("Full adress: {0}", fullAdress.Value);
                }
                else Console.WriteLine("Error");
                Console.WriteLine();
            }
            //Console.WriteLine(curFile);
        }

        public void Read(string curFile)
        {
            XmlTextReader reader = new XmlTextReader(curFile);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        Console.Write("<" + reader.Name);
                        Console.WriteLine(">");
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        Console.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        Console.Write("</" + reader.Name);
                        Console.WriteLine(">");
                        break;
                }
            }
        }

    }
}
