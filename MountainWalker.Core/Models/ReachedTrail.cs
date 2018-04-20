
namespace MountainWalker.Core.Models
{
    public class ReachedTrail
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public ReachedTrail(int id, string date, string from, string to)
        {
            Id = id;
            Date = date;
            From = from;
            To = to;
        }
    }
 }