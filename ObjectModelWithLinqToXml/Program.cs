using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using System.Xml;
using ObjectModel;

namespace ObjectModelWithLinqToXml
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BusinessLogic bussinesLogic = new BusinessLogic();

            //Show all customers
            var resultOfCustomers = bussinesLogic.ShowAllCustomers();
            Console.WriteLine();
            Console.WriteLine("All Customers and info about them:");
            foreach (var result in resultOfCustomers)
            {
                Console.WriteLine();
                Console.WriteLine("Customer ID:  {0}", result.CustomerID);
                Console.WriteLine("Company name: {0}", result.CompanyName);
                Console.WriteLine("Contact name: {0}", result.ContactName);
                Console.WriteLine("Contact title:{0}", result.ContactTitle);
                Console.WriteLine("Phone number: {0}", result.Phone);
                Console.WriteLine("Full Address:");
                Console.WriteLine("Address:      {0}", result.FullAddress.Address);
                Console.WriteLine("City:         {0}", result.FullAddress.City);
                Console.WriteLine("Region:       {0}", result.FullAddress.Region);
                Console.WriteLine("Postal Code:  {0}", result.FullAddress.PostalCode);
                Console.WriteLine("Country:      {0}", result.FullAddress.Country);
                Console.WriteLine();
            }

            //Show all orders
            var resultOfOrders = bussinesLogic.ShowAllOrders();
            Console.WriteLine();
            Console.WriteLine("All Orders and info about them:");
            foreach (var result in resultOfOrders)
            {
                Console.WriteLine();
                Console.WriteLine("Customer ID:  {0}", result.CustomerID);
                Console.WriteLine("Employee ID:  {0}", result.EmployeeID);
                Console.WriteLine("Order date:   {0}", result.OrderDate);
                Console.WriteLine("Required date:{0}", result.RequiredDate);
                Console.WriteLine("Info ship:");
                Console.WriteLine("Ship via:         {0}", result.InfoShip.ShipVia);
                Console.WriteLine("Shipped date:     {0}", result.InfoShip.ShippedDate);
                Console.WriteLine("Freight:          {0}", result.InfoShip.Freight);
                Console.WriteLine("Ship name:        {0}", result.InfoShip.ShipName);
                Console.WriteLine("Ship address:     {0}", result.InfoShip.ShipAddress);
                Console.WriteLine("Ship city:        {0}", result.InfoShip.ShipCity);
                Console.WriteLine("Ship region:      {0}", result.InfoShip.ShipRegion);
                Console.WriteLine("Ship Postal Code: {0}", result.InfoShip.ShipPostalCode);
                Console.WriteLine("Ship country:     {0}", result.InfoShip.ShipCountry);
                Console.WriteLine();
            }

            //Show all orders by tag (CustomerID)'LETSS' 
            var findByCustomerIDOnOrders = bussinesLogic.ShowByCustomerIDOnOrders();
            Console.WriteLine();
            Console.WriteLine("Orders that we can find by CustomerID on Orders are:");
            foreach (var result in findByCustomerIDOnOrders)
            {
                Console.WriteLine();
                Console.WriteLine("Tag: LETSS, Customer ID:   {0}",result.CustomerID);
                Console.WriteLine("Tag: LETSS, Employee ID:   {0}", result.EmployeeID);
                Console.WriteLine("Tag: LETSS, Order date:    {0}", result.OrderDate);
                Console.WriteLine("Tag: LETSS, Required Date: {0}", result.RequiredDate);
                Console.WriteLine("Tag: LETSS, Info ship:");
                Console.WriteLine("Tag: LETSS, Ship via:         {0}", result.InfoShip.ShipVia);
                Console.WriteLine("Tag: LETSS, Shipped date:     {0}", result.InfoShip.ShippedDate);
                Console.WriteLine("Tag: LETSS, Freight:          {0}", result.InfoShip.Freight);
                Console.WriteLine("Tag: LETSS, Ship name:        {0}", result.InfoShip.ShipName);
                Console.WriteLine("Tag: LETSS, Ship address:     {0}", result.InfoShip.ShipAddress);
                Console.WriteLine("Tag: LETSS, Ship city:        {0}", result.InfoShip.ShipCity);
                Console.WriteLine("Tag: LETSS, Ship region:      {0}", result.InfoShip.ShipRegion);
                Console.WriteLine("Tag: LETSS, Ship Postal Code: {0}", result.InfoShip.ShipPostalCode);
                Console.WriteLine("Tag: LETSS, Ship country:     {0}", result.InfoShip.ShipCountry);
                Console.WriteLine();
            }

            //Show all customers by tag (CustomerID)'HUNGC' 
            var findByCustomerIDOnCustomers = bussinesLogic.ShowByCustomerIDOnCustomers();
            Console.WriteLine();
            Console.WriteLine("Customers that we can find by CustomerID on Customers are:");
            foreach (var result in findByCustomerIDOnCustomers)
            {
                Console.WriteLine();
                Console.WriteLine("Tag: HUNGC, Customer ID:  {0}", result.CustomerID);
                Console.WriteLine("Tag: HUNGC, Company name: {0}", result.CompanyName);
                Console.WriteLine("Tag: HUNGC, Contact name: {0}", result.ContactName);
                Console.WriteLine("Tag: HUNGC, Contact title:{0}", result.ContactTitle);
                Console.WriteLine("Tag: HUNGC, Phone number: {0}", result.Phone);
                Console.WriteLine("Full Address:");
                Console.WriteLine("Tag: HUNGC, Address:      {0}", result.FullAddress.Address);
                Console.WriteLine("Tag: HUNGC, City:         {0}", result.FullAddress.City);
                Console.WriteLine("Tag: HUNGC, Region:       {0}", result.FullAddress.Region);
                Console.WriteLine("Tag: HUNGC, Postal Code:  {0}", result.FullAddress.PostalCode);
                Console.WriteLine("Tag: HUNGC, Country:      {0}", result.FullAddress.Country);
                Console.WriteLine();
            }

            //Sort orders by Enployee ID and then sort by OrderDate
            var sortOrdersByEmployeeID = bussinesLogic.ShowSortedOrdersByEmployeeID();
            Console.WriteLine();
            Console.WriteLine("Sort orders by Enployee ID:");
            foreach (var result in sortOrdersByEmployeeID)
            {
                Console.WriteLine();
                Console.WriteLine("Customer ID:   {0}", result.CustomerID);
                Console.WriteLine("Employee ID:   {0}", result.EmployeeID);
                Console.WriteLine("Order date:    {0}", result.OrderDate);
                Console.WriteLine("Required Date: {0}", result.RequiredDate);
                Console.WriteLine("Ship via:         {0}", result.InfoShip.ShipVia);
                Console.WriteLine("Shipped date:     {0}", result.InfoShip.ShippedDate);
                Console.WriteLine("Freight:          {0}", result.InfoShip.Freight);
                Console.WriteLine("Ship name:        {0}", result.InfoShip.ShipName);
                Console.WriteLine("Ship address:     {0}", result.InfoShip.ShipAddress);
                Console.WriteLine("Ship city:        {0}", result.InfoShip.ShipCity);
                Console.WriteLine("Ship region:      {0}", result.InfoShip.ShipRegion);
                Console.WriteLine("Ship Postal Code: {0}", result.InfoShip.ShipPostalCode);
                Console.WriteLine("Ship country:     {0}", result.InfoShip.ShipCountry);
                Console.WriteLine();
            }

            Console.WriteLine("End");
            Console.ReadKey();
        }
    }
    
}
