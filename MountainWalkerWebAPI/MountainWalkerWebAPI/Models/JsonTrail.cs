using System;
using System.Collections.Generic;

namespace MountainWalkerWebAPI.Models
{
    public class JsonTrail
    {
        public int Id { get; set; }

        public string Date { get; set; } = "NoDate";

        public string From { get; set; }

        public string To { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string Time { get; set; }

        public string Distance { get; set; }

        public List<int> Trails { get; set; }
    }
}
