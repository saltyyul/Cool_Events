namespace Cool_Events.Data
{
    public class Ticket:BaseEntity
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
