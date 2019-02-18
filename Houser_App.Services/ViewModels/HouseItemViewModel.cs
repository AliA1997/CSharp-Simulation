using System;
using System.Collections.Generic;
using System.Text;

namespace Houser.Services.ViewModels
{
    public class HouseItemViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Price { get; set; }
    }
}
