using System.Collections.Generic;
using MountainWalker.Core.Models;

namespace MountainWalker.Core
{
    public class ConnectionList
    {
        public List<Connection> Connections { get; private set; }

        public ConnectionList()
        {
            CreateConnections();
        }

        private void CreateConnections()
        {
            Connections.Add(new Connection());
            Connections[0].Path.Add(new Point(54.400810, 18.574563));
            Connections[0].Path.Add(new Point(54.397705, 18.577010));
        }
    }
}