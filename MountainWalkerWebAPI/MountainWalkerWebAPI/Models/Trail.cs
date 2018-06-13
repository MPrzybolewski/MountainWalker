using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MountainWalkerWebAPI.Models
{
    public class Trail
    {
		[Key]
		public int? TrailID { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public DateTime Date { get; set; }
        [ForeignKey("User")]
		public int? UserID { get; set; }
		public string StartPoint { get; set; }
		public double Distance { get; set; }
		public string EndPoint { get; set; }
    }
}
