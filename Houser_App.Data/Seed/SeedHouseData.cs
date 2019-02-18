using Houser.Data;
using Houser.Domain;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Houser_App.Data.Seed
{
    public static class SeedHouseData
    {
        public static void Seed(HouserContext context)
        {
            if(context.Houses.FirstOrDefault() == null)
            {

                House newHouse = new House("Beverly Hills Paradise", "Rich Person St.", "CA", "Beverly Hills", 00000, 1000000000);

                House newHouse1 = new House("Dump", "Skid Row", "CA", "Los Angeles", 00000, 100);

                House newHouse2 = new House("Park", "Park St.", "CA", "San Francisco", 00000, 1000);

                House newHouse3 = new House("Normal House", "America Rd.", "FL", "Tallahassee", 00000, 100000);

                House[] housesToSeed = new House[] { newHouse, newHouse1, newHouse2, newHouse3 };

                context.Houses.AddRange(housesToSeed);

                context.SaveChanges();
            }
        }

    }
}
