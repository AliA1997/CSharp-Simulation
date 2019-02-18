using System;
using System.Collections.Generic;
using System.Text;

namespace Houser.Domain
{
    public class House: Entity
    {
        private House() { }

        public House(string name, string address, string state, string city, int zipcode, int price) 
        {

            Name = name;

            Address = address;

            State = state;

            City = city;

            Zipcode = zipcode;

            Price = price;

        }

        public string Name { get; set; }

        public string Address { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public int Zipcode { get; set; }

        public int Price { get; set; }
    }
}
