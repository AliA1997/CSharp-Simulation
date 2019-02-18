using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Houser.Services.Services;
using Houser.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Houser_App.Web.Controllers
{
    [Route("api/houses")]
    public class HouseController : ControllerBase
    {
        private readonly IHousingService houseService;

        public HouseController(IHousingService _houseService)
        {
            houseService = _houseService;
        }

        // GET api/houses
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var houses = await houseService.GetHouses();

            return Ok(houses);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var house = await houseService.GetHouse(id);

            return Ok(house);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostHouse([FromBody] HouseViewModel houseCreated)
        {
            var houseToReturn = await houseService.CreateHouse(houseCreated);

            return Created("/createdhouse", houseToReturn);
        }

        // PUT api/values/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchHouse(Guid id, [FromBody] HouseViewModel updatedHouse)
        {
            await houseService.UpdateHouse(id, updatedHouse);

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHouse(Guid id)
        {
            await houseService.DeleteHouse(id);
            return Ok(id);
        }
    }
}
