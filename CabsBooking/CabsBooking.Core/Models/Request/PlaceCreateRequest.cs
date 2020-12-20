using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CabsBooking.Core.Models.Request
{
    public class PlaceCreateRequest
    {
        public int PlaceId { get; set; }

        [Required]
        [StringLength(30)]
        public string PlaceName { get; set; }
    }
}
