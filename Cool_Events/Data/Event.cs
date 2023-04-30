namespace Cool_Events.Data
{
    public class Event:BaseEntity
    {
        public Event()
        {
            Ticket = new HashSet<Ticket>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageURL { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
