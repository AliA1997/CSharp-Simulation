using System;
using System.Collections.Generic;
using System.Text;

namespace Houser.Services.ViewModels
{
    public class HouseViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public int Price { get; set; }
    }
}
