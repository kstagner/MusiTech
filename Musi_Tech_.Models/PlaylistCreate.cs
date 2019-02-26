using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musi_Tech_.Models
{
    public class PlaylistCreate
    {
       
        public string SongTitle { get; set; }      
        public string Artist { get; set; }
        public string Genre { get; set; }

        public override string ToString() => SongTitle;       
    }
}
