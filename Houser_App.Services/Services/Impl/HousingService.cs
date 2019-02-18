using Houser.Data.Repositories;
using Houser.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Houser_App.Services;
using Houser.Domain;

namespace Houser.Services.Services.Impl
{
    public class HousingService : IHousingService
    {
        private readonly IHousingRepo repo;

        public HousingService(IHousingRepo _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<HouseItemViewModel>> GetHouses()
        {
            var housesToConvert = await repo.GetHouses();

            IEnumerable<HouseItemViewModel> housesToReturn = housesToConvert.Select(house => ModelFactory.CreateItemViewModel(house));

            return housesToReturn;
        }

        public async Task<HouseViewModel> GetHouse(Guid id)
        {
            var houseToConvert = await repo.GetHouse(id);

            HouseViewModel houseToReturn = ModelFactory.CreateViewModel(houseToConvert);

            return houseToReturn;
        }

        public async Task<HouseViewModel> CreateHouse(HouseViewModel newHouse)
        {
            House houseToCreate = ModelFactory.CreateDomainModel(newHouse);

            HouseViewModel houseToReturn = ModelFactory.CreateViewModel(await repo.CreateHouse(houseToCreate));

            return houseToReturn;
        }

        public async Task UpdateHouse(Guid id, HouseViewModel updatedHouse)
        {
            House houseToUpdate = ModelFactory.CreateDomainModel(updatedHouse);

            await repo.UpdateHouse(id, houseToUpdate);

           return;
        }

        public async Task DeleteHouse(Guid id)
        {
            await repo.DeleteHouse(id);

            return;
        }
    }
}
