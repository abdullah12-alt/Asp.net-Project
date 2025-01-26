using Microsoft.EntityFrameworkCore;
using NZWalk.API.Model.Domain;

namespace NZWalk.API.Data
{
    public class NZWalkDbContext : DbContext
    {
        public NZWalkDbContext(DbContextOptions<NZWalkDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Difficulty> Difficulties { get; set; }
           public DbSet<Region> Regions { get; set; }

           public DbSet<Walk> Walks { get; set; }

    }
}
