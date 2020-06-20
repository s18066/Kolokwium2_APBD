using System;
using System.Collections;
using System.Collections.Generic;

namespace Kolokwium2.Model
{
    public class Event
    {
        public int IdEvent { get; set; }
        
        public string Name { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public virtual ICollection<ArtistEvent> ArtistEvents { get; set; }
        
        public virtual ICollection<EventOrganiser> EventOrganisers { get; set; }
    }
}