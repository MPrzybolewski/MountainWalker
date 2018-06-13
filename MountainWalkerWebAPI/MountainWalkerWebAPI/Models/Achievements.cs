using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MountainWalkerWebAPI.Models
{
	public class Achievement
    {
		[Key]
		public int? AchievementID { get; set; }
        public string Name { get; set; }
    }
}
