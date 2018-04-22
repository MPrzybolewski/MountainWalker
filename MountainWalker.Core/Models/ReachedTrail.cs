
using System.Collections.Generic;

namespace MountainWalker.Core.Models
{
    public class ReachedTrail
    {
        public int Id { get; private set; }
        public string Date { get; private set; }
        public string From { get; private set; }
        public string To { get; private set; }
        public string StartTime { get; private set; }
        public string EndTime { get; private set; }
        public string Time { get; set; }
        public string Distance { get; set; }
        public List<Point> Trail { get; private set; }

        public string Desc { get => From + ", " + To; }

        public ReachedTrail(int id, string date, string from, string to, List<Point> points)
        {
            Id = id;
            Date = date;
            From = "Początek: "+ from;
            To = "Koniec: " + to;
            Trail = points;
            StartTime = "Start: 12:45:11";
            EndTime = "Koniec: 16:53:23";
            Time = "Czas: 04:08:12";
            Distance = "Dystans: 4.23 km";
        }
    }
 }