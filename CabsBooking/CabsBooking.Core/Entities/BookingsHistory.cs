using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CabsBooking.Core.Entities
{
    [Table("Bookings_History")]
    public class BookingsHistory
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Email { get; set; }
        [Column(TypeName = "date")]
        public DateTime? BookingDate { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(5)]
        public string BookingTime { get; set; }
        public int? FromPlace { get; set; }
        public Places FromHistory { get; set; }
        public int? ToPlace { get; set; }
        public Places ToHistory { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(200)]
        public string PickupAddress { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(30)]
        public string Landmark { get; set; }
        [Column(TypeName = "date")]
        public DateTime? PickupDate { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(5)]
        public string PickupTime { get; set; }
        public int? CabTypeId { get; set; }
        public CabTypes CabTypes { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(25)]
        public string ContactNo { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(30)]
        public string Status { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(5)]
        public string Comp_Time { get; set; }
        [Column(TypeName = "money")]
        public decimal? Charge { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(1000)]
        public string Feedback { get; set; }
    }
}
