using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musi_Tech_.Data
{
    public class LessonRequest
    {
        [Key]
        public int LessonRequestID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        public string CustomerFullName { get; set; }

        [Required]
        public string Instrument { get; set; }

        [Required]
        public DateTime RequestedStartDate { get; set; }

        [Required]
        public int ZipCode { get; set; }
    }
}
