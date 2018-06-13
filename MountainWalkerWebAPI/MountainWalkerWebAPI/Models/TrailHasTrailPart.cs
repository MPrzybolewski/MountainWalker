using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MountainWalkerWebAPI.Models
{
    public class TrailHasTrailPart
    {
		[Key]
		public int TrailHasTrailPartID { get; set; }
        [ForeignKey("Trail")]
        public int? TrailID { get; set; }
        public Trail Trail { get; set; }
        [ForeignKey("TrailPart")]
        public int TrailPartID { get; set; }
        public TrailPart TrailPart { get; set; }

        public TrailHasTrailPart(int? trailID, int trailPartID)
        {
            TrailID = trailID;
            TrailPartID = trailPartID;
        }
    }
}
