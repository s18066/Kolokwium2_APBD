namespace Kolokwium2.Model
{
    public class EventOrganiser
    {
        
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
        
        public int OrganiserId { get; set; }
        
        public virtual Organiser Organiser { get; set; }
    }
}