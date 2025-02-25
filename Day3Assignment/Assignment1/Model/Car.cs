using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Assignment1.Model
{
    internal class Car
    {
        // Private Fields
        private int carID;
        private string brand;
        private string model;
        private int year;
        private double price;

        // Public Properties
        public int CarID
        {
            get { return carID; }
            set { carID = value; }
        }
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public Car()
        {
            CarID = 1;
            Brand = "TestBrand";
            Model = "TestModel";
            Year = 2024;
            Price = 0;

        }
        public Car(int cid, string br, string mod, int yr, double amt)
        {
            CarID = cid;
            Brand = br;
            Model = mod;
            Year = yr;
            Price = amt;
        }

        public void SetCarDetails(int cid, string br, string mod, int yr, double amt)
        {
            CarID = cid;
            Brand = br;
            Model = mod;
            Year = yr;
            Price = amt;
            Console.WriteLine("Receiving Car Information...");
        }
        public void GetCarDetails()
        {
            Console.WriteLine("Presenting Car Information");
            Console.WriteLine($"ID: {CarID} \t Brand: {Brand} \t Model: {Model} \t Year: {Year} \t Price: {Price}");
        }
    }
}
