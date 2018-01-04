using System.Collections.Generic;

namespace MountainWalker.Core.Models
{
    public class Connection
    {
        public int Id { get; set; }
        public List<Point> Path { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }


        public Connection()
        {
            Path = new List<Point>();
        }
    }
}