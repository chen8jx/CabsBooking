using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CabsBooking.Core.Models.Request
{
    public class CabCreateRequest
    {
        public int CabTypeId { get; set; }

        [Required]
        [StringLength(30)]
        public string CabTypeName { get; set; }
    }
}
