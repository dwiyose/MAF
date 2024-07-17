using Microsoft.EntityFrameworkCore;

namespace Master.Models
{
    public class MasterDBContext : DbContext
    {
        public MasterDBContext(DbContextOptions<MasterDBContext> options) : base(options)
        {
        }

        public DbSet<ms_user> ms_user { get; set; }
        public DbSet<ms_location> ms_location_storage { get; set; }

    }
}
