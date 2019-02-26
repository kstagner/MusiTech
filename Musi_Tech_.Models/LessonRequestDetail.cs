using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musi_Tech_.Models
{
    public class LessonRequestDetail
    {
        [Display(Name = "RequestID")]
        public int LessonRequestID { get; set; }

        [Display(Name = "Name")]
        public string CustomerFullName { get; set; }


        public string Instrument { get; set; }
        public DateTime RequestedStartDate { get; set; }
        public int ZipCode { get; set; }
        public override string ToString() => $"[{LessonRequestID}] {CustomerFullName}";
    }
}
