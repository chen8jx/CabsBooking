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
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpPost]
        [Route("booking")]
        public async Task<IActionResult> CreateBooking(BookingCreateRequest bookingCreateRequest)
        {
            if (ModelState.IsValid)
            {
                await _bookingService.AddBooking(bookingCreateRequest);
                return Ok(bookingCreateRequest);
            }
            return BadRequest(new { message = "please correct the booking input information" });
        }
        [HttpPut]
        [Route("booking")]
        public async Task<IActionResult> UpdateBooking(BookingCreateRequest bookingCreateRequest)
        {
            if (ModelState.IsValid)
            {
                await _bookingService.UpdateBooking(bookingCreateRequest);
                return Ok(bookingCreateRequest);
            }
            return BadRequest(new { message = "please correct the booking input information" });
        }
        [HttpDelete]
        [Route("{bookingId:int}")]
        public async Task<IActionResult> DeleteBooking(int bookingId)
        {
            await _bookingService.DeleteBooking(bookingId);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookings();
            return Ok(bookings);
        }
    }
}
