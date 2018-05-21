
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MountainWalker.Core.Models
{
    public class ReachedTrail
    {
        [JsonProperty("trailID")]
        public int Id { get; set; }

        public string Date { get; set; } = "Pluszak nie dodał daty";

        [JsonProperty("startPoint")]
        public string From { get; set; }

        [JsonProperty("endPoint")]
        public string To { get; set; }

        [JsonProperty("startTime")]
        public string StartTime { get; set; }

        [JsonProperty("endTime")]
        public string EndTime { get; set; }

        public string Time { get; set; }

        [JsonProperty("distance")]
        public string Distance { get; set; }

        [JsonProperty("trailParts")]
        public List<int> Trails { get; set; }

        public string Desc { get => From + ", " + To; }

        public ReachedTrail() {}

        public ReachedTrail(int id, string date, string from, string to, List<int> trails)
        {
            Id = id;
            Date = date;
            From = "Początek: "+ from;
            To = "Stop: " + to;
            Trails = trails;
            StartTime = "Start: 12:45:11";
            EndTime = "Koniec: 16:53:23";
            Time = "04:08:12";
            Distance = "4.23 km";
        }
    }
 }