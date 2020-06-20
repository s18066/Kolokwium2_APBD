using System;

namespace Kolokwium2.Model
{
    public class ArtistEvent
    {
        public virtual Artist Artist { get; set; }
        
        public virtual Event Event { get; set; }
        
        public DateTime PerformanceDate { get; set; }
    }
}