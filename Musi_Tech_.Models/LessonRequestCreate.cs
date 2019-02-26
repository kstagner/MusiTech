using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musi_Tech_.Models
{
    public class LessonRequestCreate
    {
        [Required]
        public string CustomerFullName { get; set; }

        [Required]
        public string Instrument { get; set; }
      
        [Required]
        public DateTime RequestStartDate { get; set; }
        
        [Required]
        public int ZipCode { get; set; }

        public override string ToString() => Instrument;
    }

}
