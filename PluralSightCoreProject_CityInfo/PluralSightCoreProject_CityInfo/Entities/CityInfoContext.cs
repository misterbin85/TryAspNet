using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PluralSightCoreProject_CityInfo.Models;

namespace PluralSightCoreProject_CityInfo.Entities
{
    public class CityInfoContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public static string CityInfoDbConnectionString;
        public DbSet<PointOfInterest> PointOfInterests { get; set; }

        public CityInfoContext(DbContextOptions<CityInfoContext> contextOptions, IOptions<ConnectionStringsModel> options)
            : base(contextOptions)
        {
            CityInfoDbConnectionString = options.Value.CityInfoDbConnectionString;
            Database.Migrate();

            // Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CityInfoDbConnectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}