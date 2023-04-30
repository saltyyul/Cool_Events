using Cool_Events.Data;

namespace Cool_Events.Models
{
    public class TicketVM
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
