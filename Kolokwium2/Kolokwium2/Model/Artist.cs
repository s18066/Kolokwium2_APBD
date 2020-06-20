using System.Collections;
using System.Collections.Generic;

namespace Kolokwium2.Model
{
    public class Artist
    {
        public int IdArtist { get; set; }
        
        public string Nickname { get; set; }
        
        public virtual ICollection<ArtistEvent> ArtistEvents { get; set; }
    }
}