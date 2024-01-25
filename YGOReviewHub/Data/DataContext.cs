using Microsoft.EntityFrameworkCore;
using YGOReviewHub.Models;

namespace YGOReviewHub.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Deck> Decks { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<Models.Type> Types { get; set; }
        public DbSet<YugiohCard> YugiohCards { get; set; }
        public DbSet<YugiohCardOwner> YugiohCardOwners { get; set; }
        public DbSet<YugiohCardType> YugiohCardTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
