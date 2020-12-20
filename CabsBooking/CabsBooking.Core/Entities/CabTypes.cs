using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CabsBooking.Core.Entities
{
    [Table("CabTypes")]
    public class CabTypes
    {
        [Key]
        public int CabTypeId { get; set; }

        [MaxLength(30)]
        [Column(TypeName ="varchar")]
        public string CabTypeName { get; set; }
        public ICollection<Bookings> Bookings { get; set; }
        public ICollection<BookingsHistory> BookingsHistory { get; set; }
    }
}
