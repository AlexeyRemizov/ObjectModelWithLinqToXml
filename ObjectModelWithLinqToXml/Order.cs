using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ObjectModelWithLinqToXml;

namespace ObjectModel
{
    public class Order
    {
        public string CustomerID;  //LETSS

        public  string EmployeeID; 

        public DateTime OrderDate;

        public DateTime RequiredDate;

        public DateTime ShippedDate;

        public ShipInfo InfoShip;
        

        public Order()
        {

        }

       
        
    }
}
