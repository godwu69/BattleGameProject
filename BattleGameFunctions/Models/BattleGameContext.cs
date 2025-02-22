using Microsoft.EntityFrameworkCore;

namespace BattleGameFunctions.Models
{
    public class BattleGameContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<PlayerAsset> PlayerAssets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("YourConnectionStringHere");
        }
    }
}