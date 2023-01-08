using Microsoft.EntityFrameworkCore;

namespace mathsociety.DAL
{
    public class AnnouncementDbContext : DbContext
    {
        public AnnouncementDbContext(DbContextOptions<AnnouncementDbContext> options) : base(options)
        {
        }

        public DbSet<mathsociety.Models.Announcement> Announcement { get; set; }
    }
}
