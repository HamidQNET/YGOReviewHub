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
            modelBuilder.Entity<YugiohCardOwner>()
                .HasKey(yo => new { yo.YugiohCardId, yo.OwnerId });
            modelBuilder.Entity<YugiohCardOwner>()
                .HasOne(y => y.YugiohCard)
                .WithMany(yo => yo.YugiohCardOwners)
                .HasForeignKey(y => y.YugiohCardId);
            modelBuilder.Entity<YugiohCardOwner>()
                .HasOne(y => y.Owner)
                .WithMany(yo => yo.YugiohCardOwners)
                .HasForeignKey(o => o.OwnerId);

            modelBuilder.Entity<YugiohCardType>()
                .HasKey(yt => new { yt.YugiohCardId, yt.TypeId });
            modelBuilder.Entity<YugiohCardType>()
                .HasOne(y => y.YugiohCard)
                .WithMany(yt => yt.YugiohCardTypes)
                .HasForeignKey(y => y.YugiohCardId);
            modelBuilder.Entity<YugiohCardType>()
                .HasOne(y => y.Type)
                .WithMany(yo => yo.YugiohCardTypes)
                .HasForeignKey(o => o.TypeId);


        }
    }
}
