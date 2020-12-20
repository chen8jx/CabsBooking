using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CabsBooking.Core.Models.Request
{
    public class BHistoryCreateRequest
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }
        public DateTime? BookingDate { get; set; }
        [RegularExpression("^[0-2][0-3]:[0-5][0-9]$")]
        public string BookingTime { get; set; }
        public int? FromPlace { get; set; }
        //public Places FromPlaces { get; set; }
        public int? ToPlace { get; set; }
        //public Places ToPlaces { get; set; }
        public string PickupAddress { get; set; }
        public string Landmark { get; set; }
        public DateTime? PickupDate { get; set; }
        [RegularExpression("^[0-2][0-3]:[0-5][0-9]$")]
        public string PickupTime { get; set; }
        public int? CabTypeId { get; set; }
        //public CabTypes CabTypes { get; set; }
        public string ContactNo { get; set; }
        //[Required]
        public string Status { get; set; }
        [RegularExpression("^[0-2][0-3]:[0-5][0-9]$")]
        public string Comp_Time { get; set; }
        //[Range(0, 5000000000)]
        //[RegularExpression("^(\\d{1,18})(.\\d{1})?$")]
        public decimal? Charge { get; set; }
        public string Feedback { get; set; }
    }
}
