using System;

namespace Kolokwium2.Model
{
    public class ArtistEvent
    {
        
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
        
        public int EventId { get; set; }
        
        public virtual Event Event { get; set; }
        
        public DateTime PerformanceDate { get; set; }
    }
}