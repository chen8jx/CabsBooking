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
    public class CabTypesController : ControllerBase
    {
        private readonly ICabService _cabService;
        public CabTypesController(ICabService cabService)
        {
            _cabService = cabService;
        }
        [HttpPost]
        [Route("cab")]
        public async Task<IActionResult> CreateCab(CabCreateRequest cabCreateRequest)
        {
            if (ModelState.IsValid)
            {
                await _cabService.AddCab(cabCreateRequest);
                return Ok(cabCreateRequest);
            }
            return BadRequest(new { message = "please correct the cab input information" });
        }
        [HttpPut]
        [Route("cab")]
        public async Task<IActionResult> UpdateCab(CabCreateRequest cabCreateRequest)
        {
            if (ModelState.IsValid)
            {
                var cab = await _cabService.UpdateCab(cabCreateRequest);
                return Ok(cab);
            }
            return BadRequest(new { message = "please correct the cab input information" });
        }
        [HttpDelete]
        [Route("{cabId:int}")]
        public async Task<IActionResult> DeleteCab(int cabId)
        {
            await _cabService.DeleteCab(cabId);
            return Ok();
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllCabs()
        {
            var dbCabs = await _cabService.GetAllCabs();
            return Ok(dbCabs);
        }
        [HttpGet]
        [Route("{cabId:int}")]
        public async Task<IActionResult> GetCab(int cabId)
        {
            var dbCabs = await _cabService.GetCabDetails(cabId);
            return Ok(dbCabs);
        }
    }
}
