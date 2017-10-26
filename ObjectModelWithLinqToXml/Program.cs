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
        /*public static string curFilePath = ConfigurationManager.AppSettings[@"Path"];

        //public string filePath = (Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory)) + curFilePath;

        public XDocument xDoc = XDocument.Load(Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + curFilePath);

    */
        public static void Main(string[] args)
        {

            DAL = new DAl(xmlpath);
            List<Order> orders = DAL.ReadOrders();
            customers = DAL.GetCustomers();
        }
    }
    
}
