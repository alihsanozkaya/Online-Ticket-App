using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online_Ticket_App.Models;

namespace Online_Ticket_App.Utility
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<Concert> concerts { get; set; }
        public DbSet<Theater> theaters { get; set; }
        public DbSet<Sport> sports { get; set; }
        public DbSet<Ticket> tickets { get; set; }
        public DbSet<Category> categories { get; set; }

    }
}
