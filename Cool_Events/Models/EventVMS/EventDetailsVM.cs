using Cool_Events.Data;

namespace Cool_Events.Models.EventVMS
{
    public class EventDetailsVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageURL { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
