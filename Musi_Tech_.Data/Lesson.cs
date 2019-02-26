using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musi_Tech_.Data
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Instrument { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Cost { get; set; }
    }
}
