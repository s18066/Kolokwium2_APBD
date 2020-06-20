using System;

namespace Kolokwium2.Model
{
    public class Event
    {
        public int IdEvent { get; }
        
        public string Name { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
    }
}