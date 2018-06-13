using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MountainWalkerWebAPI.Models
{
    public class UserAchievement
    {
		[Key]
		public int? UserAchievementID;
		[ForeignKey("User")]
		public int UserID { get; set; }
		public User User { get; set; }
		[ForeignKey("Achievement")]
		public int AchievementID { get; set; }
		public Achievement Achievement { get; set; }
		public DateTime Date { get; set; }
    }
}
