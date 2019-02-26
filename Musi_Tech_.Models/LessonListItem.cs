using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musi_Tech_.Models
{
    public class LessonListItem
    {
        [Display(Name = "Lesson")]
        public int LessonId { get; set; }

        public string Instrument { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }

        public override string ToString() => Instrument;
    }
}
