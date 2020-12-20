using CabsBooking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CabsBooking.Core.Models.Reponse
{
    public class CabBookingsDetailsResponse
    {
        public int CabTypeId { get; set; }
        public string CabTypeName { get; set; }
        public List<BookingDetailsReponse> Bookings { get; set; }//bookings history
    }
}
