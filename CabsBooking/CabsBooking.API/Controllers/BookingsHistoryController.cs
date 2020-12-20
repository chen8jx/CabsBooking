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
    public class BookingsHistoryController : ControllerBase
    {
        private readonly IBHistoryService _bHistoryService;
        public BookingsHistoryController(IBHistoryService bHistoryService)
        {
            _bHistoryService = bHistoryService;
        }
        [HttpPost]
        [Route("history")]
        public async Task<IActionResult> CreateHistory(BHistoryCreateRequest bHistoryCreateRequest)
        {
            if (ModelState.IsValid)
            {
                await _bHistoryService.AddBHistory(bHistoryCreateRequest);
                return Ok(bHistoryCreateRequest);
            }
            return BadRequest(new { message = "please correct the booking_history input information" });
        }
        [HttpPut]
        [Route("history")]
        public async Task<IActionResult> UpdateHistory(BHistoryCreateRequest bHistoryCreateRequest)
        {
            if (ModelState.IsValid)
            {
                await _bHistoryService.UpdateBHistory(bHistoryCreateRequest);
                return Ok(bHistoryCreateRequest);
            }
            return BadRequest(new { message = "please correct the booking_history input information" });
        }
        [HttpDelete]
        [Route("{bookinghistoryId:int}")]
        public async Task<IActionResult> DeleteHistory(int bookinghistoryId)
        {
            await _bHistoryService.DeleteBHistory(bookinghistoryId);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHistory()
        {
            var history = await _bHistoryService.GetAllBHistory();
            return Ok(history);
        }
    }
}
