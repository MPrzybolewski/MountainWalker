using System.Collections.Generic;

namespace MountainWalker.Core.Models
{
    public class Connection
    {
        public List<Point> Path { get; set; }
        public string Color { get; set; }

        public Connection()
        {
            Path = new List<Point>();
        }
    }
}