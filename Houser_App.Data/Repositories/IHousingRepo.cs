using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Houser.Domain;

namespace Houser.Data.Repositories
{
    public interface IHousingRepo
    {
        Task<IEnumerable<House>> GetHouses();

        Task<House> GetHouse(Guid id);

        Task<House> CreateHouse(House newHouse);

        Task UpdateHouse(Guid id, House updatedHouse);

        Task DeleteHouse(Guid id);
    }
}
