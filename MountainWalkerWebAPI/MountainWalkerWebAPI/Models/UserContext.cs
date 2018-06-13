using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MountainWalkerWebAPI.Models;

namespace MountainWalkerWebAPI.Models
{
    public class UserContext : DbContext
    {

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

		protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Define composite key.
			builder.Entity<UserAchievement>()
                .HasKey(t => new { t.UserID, t.AchievementID });

			builder.Entity<TrailHasTrailPart>()
                .HasKey(t => new { t.TrailID, t.TrailPartID });
        }
        public DbSet<User> Users { get; set; }
		public DbSet<Achievement> Achievement { get; set; }
		public DbSet<UserAchievement> UserAchievement { get; set; }
		public DbSet<Trail> Trail { get; set; }
		public DbSet<TrailPart> TrailParts { get; set; }
		public DbSet<TrailHasTrailPart> TrailHasTrailPart { get; set; }
    }
}
