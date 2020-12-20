using CabsBooking.Core.Models.Request;
using CabsBooking.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabsBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly IPlaceService _placeService;
        public PlacesController(IPlaceService placeService)
        {
            _placeService = placeService;
        }
        [HttpPost]
        [Route("place")]
        public async Task<IActionResult> CreatePlace(PlaceCreateRequest placeCreateRequest)
        {
            if (ModelState.IsValid)
            {
                await _placeService.AddPlace(placeCreateRequest);
                return Ok(placeCreateRequest);
            }
            return BadRequest(new { message = "please correct the place input information" });
        }
        [HttpPut]
        [Route("place")]
        public async Task<IActionResult> UpdatePlace(PlaceCreateRequest placeCreateRequest)
        {
            if (ModelState.IsValid)
            {
                await _placeService.UpdatePlace(placeCreateRequest);
                return Ok(placeCreateRequest);
            }
            return BadRequest(new { message = "please correct the place input information" });
        }
        [HttpDelete]
        [Route("{placeId:int}")]
        public async Task<IActionResult> DeletePlace(int placeId)
        {
            await _placeService.DeletePlace(placeId);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPlaces()
        {
            var places = await _placeService.GetAllPlaces();
            return Ok(places);
        }
    }
}
