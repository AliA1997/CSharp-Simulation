using Houser.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Houser.Services.Services
{
    public interface IHousingService
    {
       
        Task<IEnumerable<HouseItemViewModel>> GetHouses();

        Task<HouseViewModel> GetHouse(Guid id);

        Task<HouseViewModel> CreateHouse(HouseViewModel newHouse);

        Task UpdateHouse(Guid id, HouseViewModel updatedHouse);

        Task DeleteHouse(Guid id);

    }
}
