
using System.Collections.Generic;

namespace MountainWalker.Core.Models
{
    public class ReachedTrail
    {
        public int Id { get; private set; }
        public string Date { get; private set; }
        public string From { get; private set; }
        public string To { get; private set; }
        public List<Point> Trail { get; private set; }

        public ReachedTrail(int id, string date, string from, string to, List<Point> points)
        {
            Id = id;
            Date = date;
            From = from;
            To = to;
            Trail = points;
        }
    }
 }