using Houser.Domain;
using Houser.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Houser_App.Services
{
    public static class ModelFactory
    {
        public static HouseItemViewModel CreateItemViewModel(House houseToConvert)
        {
            return new HouseItemViewModel()
            {
                Id = houseToConvert.Id,
                Name = houseToConvert.Name,
                Address = $"{houseToConvert.Address}, {houseToConvert.City}, {houseToConvert.State}, #{houseToConvert.Zipcode}.",
                Price = houseToConvert.Price
                    
            };
        }

        public static HouseViewModel CreateViewModel(House houseToConvert)
        {
            return new HouseViewModel()
            {
                Name = houseToConvert.Name,
                Address = houseToConvert.Address,
                State = houseToConvert.State,
                City = houseToConvert.City,
                Zipcode = houseToConvert.Zipcode,
                Price = houseToConvert.Price

            };
        }

        public static House CreateDomainModel(HouseViewModel houseViewModelToConvert)
        {
            return new House(
                    name: houseViewModelToConvert.Name,
                    address: houseViewModelToConvert.Address,
                    state: houseViewModelToConvert.State,
                    city: houseViewModelToConvert.City,
                    zipcode: houseViewModelToConvert.Zipcode,
                    price: houseViewModelToConvert.Price
                );
        }

    }
}
