using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CabsBooking.Core.Entities
{
    [Table("Places")]
    public class Places
    {
        [Key]
        public int PlaceId { get; set; }

        [Column(TypeName ="varchar")]
        [MaxLength(30)]
        public string PlaceName { get; set; }
        public ICollection<Bookings> FromPlaces { get; set; }
        public ICollection<Bookings> ToPlaces { get; set; }

        public ICollection<BookingsHistory> FromHistory { get; set; }
        public ICollection<BookingsHistory> ToHistory { get; set; }

    }
}
