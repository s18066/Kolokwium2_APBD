namespace Kolokwium2.Model
{
    public class EventOrganiser
    {
        public virtual Event Event { get; set; }
        
        public virtual Organiser Organiser { get; set; }
    }
}