using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ObjectModel
{
    public class Paths
    {
        public readonly static string SampleDataFolder = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);

        public static string CustomersAndOrders = SampleDataFolder + @"\CustomersOrdersInNamespace.xml";

        public readonly static XNamespace ns = "http://www.adventure-works.com";

        public static XDocument XDoc = XDocument.Load(CustomersAndOrders);


        public static XDocument GetData()
        {
            string path = CustomersAndOrders;
            XDocument xDoc = XDocument.Load(@path);
            return xDoc;
        }
        
    }
}
