using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musi_Tech_.Data
{
    public class Playlist
    {
        [Key]
        public int SongID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        public string SongTitle { get; set; }

        [Required]
        public string Artist { get; set; }

        [Required]
        public string Genre { get; set; }
    }
}
