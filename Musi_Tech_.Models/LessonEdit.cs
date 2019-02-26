using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musi_Tech_.Models
{
    public class LessonEdit
    {
        public int LessonId { get; set; }
        public string Instrument { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
    }
}
