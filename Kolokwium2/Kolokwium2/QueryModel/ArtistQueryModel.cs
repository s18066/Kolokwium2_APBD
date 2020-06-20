using System;
using System.Collections;
using System.Collections.Generic;

namespace Kolokwium2.QueryModel
{
    public class ArtistQueryModel
    {
        public int Id { get; set; }
        
        public string Nickname { get; set; }
        
        public IEnumerable<EventQueryModel> Events { get; set; }
    }

    public class EventQueryModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
    }
}