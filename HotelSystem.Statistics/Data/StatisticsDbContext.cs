using HotelSystem.Statistics.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Statistics.Data
{
    public class StatisticsDbContext : DbContext
    {
        public StatisticsDbContext(DbContextOptions<StatisticsDbContext> options)
            :base(options)
        {

        }
        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<StatisticsModel> Statistics { get; set; }

        public DbSet<HotelView> HotelViews { get; set; }
    }
}
