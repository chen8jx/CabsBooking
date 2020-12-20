using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CabsBooking.Core.Models.Request
{
    public class BookingCreateRequest
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }
        public DateTime? BookingDate { get; set; }
        public string BookingTime { get; set; }
        public int? FromPlace { get; set; }
        //public Places FromPlaces { get; set; }
        public int? ToPlace { get; set; }
        //public Places ToPlaces { get; set; }
        public string PickupAddress { get; set; }
        public string Landmark { get; set; }
        public DateTime? PickupDate { get; set; }
        public string PickupTime { get; set; }
        public int? CabTypeId { get; set; }
        //public CabTypes CabTypes { get; set; }
        public string ContactNo { get; set; }
        public string Status { get; set; }
    }
}
