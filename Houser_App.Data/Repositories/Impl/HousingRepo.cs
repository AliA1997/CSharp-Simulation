using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Houser.Data.Repositories;
using Houser.Domain;
using Microsoft.EntityFrameworkCore;

namespace Houser.Data.Repositories.Impl
{
    public class HousingRepo : IHousingRepo
    {
        private readonly HouserContext context;

        public HousingRepo(HouserContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<House>> GetHouses()
        {

            IEnumerable<House> housesToReturn = await context.Houses.ToListAsync();

            return housesToReturn;

        }

        public async Task<House> GetHouse(Guid id)
        {

            House houseToReturn = await context.Houses.FirstOrDefaultAsync(house => house.Id == id);

            return houseToReturn;

        }

        public async Task<House> CreateHouse(House newHouse)
        {

            await context.Houses.AddAsync(newHouse);

            await context.SaveChangesAsync();

            return newHouse;

        }

        public async Task UpdateHouse(Guid id, House updatedHouse)
        {
            updatedHouse.Id = id;

            context.Houses.Update(updatedHouse);

            context.SaveChanges();

            return;
        }

        public async Task DeleteHouse(Guid id)
        {
            House houseToDelete = await context.Houses.FirstOrDefaultAsync(house => house.Id == id);

            context.Houses.Remove(houseToDelete);

            await context.SaveChangesAsync();

            return;

        }
    }
}
