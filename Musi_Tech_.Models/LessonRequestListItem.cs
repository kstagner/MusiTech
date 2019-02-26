using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musi_Tech_.Models
{
    public class LessonRequestListItem
    {
        [Display(Name = "Request ID")]
        public int LessonRequestID { get; set; }

        [Display(Name = "Name")]
        public string CustomerFullName { get; set; }

        public string Instrument { get; set; }
     
        [Display(Name = "Available Start Date")]
        public DateTime RequestedStartDate { get; set; }

        public override string ToString() => Instrument;
    }

}
