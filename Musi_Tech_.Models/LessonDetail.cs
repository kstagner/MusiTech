using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musi_Tech_.Models
{
    public class LessonDetail
    {
        [Display(Name = "Lesson")]
        public int LessonID { get; set; }
        public string Instrument { get; set; }
        [Display(Name = "Customer")]
        public int CustomerID { get; set; }
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
    }
}
