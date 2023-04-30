using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Cool_Events.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<User>? User { get; set; }
        public DbSet<Event>? Event { get; set; }
        public DbSet<Ticket>? Tickets { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany(u => u.Ticket)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Event)
                .WithMany(u => u.Ticket)
                .HasForeignKey(t => t.EventId);

            modelBuilder.Entity<Ticket>()
                .HasKey(t => new { t.UserId, t.EventId });
        }
    }
}