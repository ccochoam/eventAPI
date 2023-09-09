using Microsoft.EntityFrameworkCore;
using LogAPI.Entities.Models;
using LogAPI.Data.Interface;

namespace LogAPI.Data.Context
{
    public class LogEventDbContext: DbContext, ILogEventDbContext
    {
        public LogEventDbContext(DbContextOptions<LogEventDbContext> options) : base(options)
        {

        }

        public DbSet<Event> Event { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Event>(Entities =>
            {
                Entities.HasKey(e => e.Id);
                Entities.HasIndex(e => e.Id);
                Entities.Property(e => e.Description);
                Entities.Property(e => e.EventType);
                Entities.Property(e => e.EventDate);
            });
        }
    }
}
