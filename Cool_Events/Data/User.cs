using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Net.Sockets;

namespace Cool_Events.Data
{
    public class User:IdentityUser
    {
        public User()
        {
            Ticket = new HashSet<Ticket>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Ticket>? Ticket { get; set; }
    }
}
