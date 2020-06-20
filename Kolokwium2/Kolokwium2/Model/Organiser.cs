using System.Collections;
using System.Collections.Generic;

namespace Kolokwium2.Model
{
    public class Organiser
    {
        public int IdOrganiser { get; set; }
        
        public string Name { get; set; }
        
        public virtual ICollection<EventOrganiser> EventOrganisers { get; set; }
    }
}