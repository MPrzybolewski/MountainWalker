using System;
using System.ComponentModel.DataAnnotations;

namespace MountainWalkerWebAPI.Models
{
    public class TrailPart
    {
		[Key]
		public int TrailPartID { get; set; }
		public string Name { get; set; }

        public TrailPart(int id, string name)
        {
            TrailPartID = id;
            Name = name;
        }
    }
}
