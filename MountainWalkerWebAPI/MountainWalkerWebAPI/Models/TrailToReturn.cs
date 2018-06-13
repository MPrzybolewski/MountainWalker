using System;
using System.Collections.Generic;
using System.Linq;

namespace MountainWalkerWebAPI.Models
{
    public class TrailToReturn
    {
		public TrailToReturn()
		{
			TrailParts = new List<int>();
		}

		public int? TrailID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string StartPoint { get; set; }
        public double Distance { get; set; }
        public string EndPoint { get; set; }
		public DateTime Date { get; set; }
		public List<int> TrailParts { get; set; }
    }
}
