using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using MountainWalker.Core.Models;

namespace MountainWalker.Core
{
    public class ConnectionList
    {
        public List<Connection> Connections { get; private set; }

        public ConnectionList()
        {
            Connections = new List<Connection>();
            CreateConnections();
        }

        private void CreateConnections()
        {

            //////////////////////// Test Trail ////////////////////////
            Connections.Add(new Connection());
            Connections[0].Color = "blue";
            Connections[0].Path.Add(new Point(54.400647, 18.576544));
            Connections[0].Path.Add(new Point(54.400528, 18.576064));
            Connections[0].Path.Add(new Point(54.400712, 18.575901));
            Connections[0].Path.Add(new Point(54.400772, 18.575757));
            Connections[0].Path.Add(new Point(54.400763, 18.575352));
            Connections[0].Path.Add(new Point(54.401061, 18.575101));
            Connections[0].Path.Add(new Point(54.400818, 18.574548));
            Connections[0].Path.Add(new Point(54.400810, 18.574563));
            Connections[0].Path.Add(new Point(54.399849, 18.575161));
            Connections[0].Path.Add(new Point(54.399249, 18.575701));
            Connections[0].Path.Add(new Point(54.397705, 18.577010));
            Connections[0].Path.Add(new Point(54.397800, 18.576788));
            Connections[0].Path.Add(new Point(54.397216, 18.575113));
            Connections[0].Path.Add(new Point(54.396893, 18.575427));
            Connections[0].Path.Add(new Point(54.396567, 18.574493));
            Connections[0].Path.Add(new Point(54.396324, 18.573653));
            Connections[0].Path.Add(new Point(54.396269, 18.573682));
            Connections[0].Path.Add(new Point(54.396157, 18.573419));
            Connections[0].Path.Add(new Point(54.396110, 18.573478));

            //////////////////////// Road to Kfc will be second trail :D
            
            Connections.Add(new Connection());
            Connections[1].Color = "red";
            Connections[1].Path.Add(new Point(54.396567, 18.574493));
            Connections[1].Path.Add(new Point(54.396234, 18.576797));
            Connections[1].Path.Add(new Point(54.396250, 18.576855));
            Connections[1].Path.Add(new Point(54.395049, 18.578130));
            Connections[1].Path.Add(new Point(54.395168, 18.578796));
            Connections[1].Path.Add(new Point(54.395168, 18.578796));
            Connections[1].Path.Add(new Point(54.394951, 18.579512));
            Connections[1].Path.Add(new Point(54.394851, 18.579476));
            Connections[1].Path.Add(new Point(54.394427, 18.580052));
            Connections[1].Path.Add(new Point(54.394339, 18.579982));

            ///////////////////////// Now Finaly road to Ygrek!
            
            Connections.Add(new Connection());
            Connections[2].Color = "green";
            Connections[2].Path.Add(new Point(54.396157, 18.573419));
            Connections[2].Path.Add(new Point(54.396257, 18.573158));
            Connections[2].Path.Add(new Point(54.396260, 18.573036));
            Connections[2].Path.Add(new Point(54.396334, 18.572951));
            Connections[2].Path.Add(new Point(54.396069, 18.572149));
            Connections[2].Path.Add(new Point(54.395930, 18.571766));
            Connections[2].Path.Add(new Point(54.395803, 18.571331));
            Connections[2].Path.Add(new Point(54.395861, 18.571273));
            Connections[2].Path.Add(new Point(54.395916, 18.570889));
            Connections[2].Path.Add(new Point(54.395916, 18.570889));
            Connections[2].Path.Add(new Point(54.394995, 18.569080));
            Connections[2].Path.Add(new Point(54.394840, 18.569100));
            Connections[2].Path.Add(new Point(54.394840, 18.569100));
            Connections[2].Path.Add(new Point(54.394563, 18.569352));
            Connections[2].Path.Add(new Point(54.394362, 18.569519));
            Connections[2].Path.Add(new Point(54.393983, 18.569646));

        }
    }
}