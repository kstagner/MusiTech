using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musi_Tech_.Models
{
    public class LessonRequestEdit
    {
        public int LessonRequestID { get; set; }
        public string CustomerFullName { get; set; }
        public string Instrument { get; set; }
        public DateTime RequestStartDate { get; set; }
        public int ZipCode { get; set; }
    }
}
