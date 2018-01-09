﻿using System.Collections.Generic;
using MountainWalker.Core.Models;

namespace MountainWalker.Core.Interfaces.Impl
{
    public class TrailService : ITrailService
    {
        public List<Point> Points { get; set; }
        public List<Connection> Trails { get; set; }

        public TrailService()
        {
            Points = new List<Point>();
            ReadAllPoints();

            Trails = new List<Connection>();
            CreateConnections();
            
        }

        private void ReadAllPoints()
        {
            Points.Add(new Point(54.400680, 18.576661)); //skm
            Points.Add(new Point(54.400810, 18.574563)); //grunwaldzka
            Points.Add(new Point(54.397705, 18.577010)); //przejscie
            Points.Add(new Point(54.396158, 18.573407)); //Mfi kckckc
            Points.Add(new Point(54.394345, 18.579970)); //KFC
            Points.Add(new Point(54.394121, 18.569394)); //Ygrek <3
            Points.Add(new Point(54.034417, 19.033257)); //Malbork
        }

        private void CreateConnections()
        {

            //////////////////////// Test Trail ////////////////////////
            Trails.Add(new Connection());
            Trails[0].Color = "blue";
            Trails[0].Id = 0;
            Trails[0].Description = "Legendary main road from SKM to UG";
            Trails[0].Name = "Dolina Alchemii";
            Trails[0].Path.Add(new Point(54.400647, 18.576544));
            Trails[0].Path.Add(new Point(54.400528, 18.576064));
            Trails[0].Path.Add(new Point(54.400712, 18.575901));
            Trails[0].Path.Add(new Point(54.400772, 18.575757));
            Trails[0].Path.Add(new Point(54.400763, 18.575352));
            Trails[0].Path.Add(new Point(54.401061, 18.575101));
            Trails[0].Path.Add(new Point(54.400818, 18.574548));
            Trails[0].Path.Add(new Point(54.400810, 18.574563));
            Trails[0].Path.Add(new Point(54.399849, 18.575161));
            Trails[0].Path.Add(new Point(54.399249, 18.575701));
            Trails[0].Path.Add(new Point(54.397705, 18.577010));
            Trails[0].Path.Add(new Point(54.397800, 18.576788));
            Trails[0].Path.Add(new Point(54.397216, 18.575113));
            Trails[0].Path.Add(new Point(54.396893, 18.575427));
            Trails[0].Path.Add(new Point(54.396567, 18.574493));
            Trails[0].Path.Add(new Point(54.396324, 18.573653));
            Trails[0].Path.Add(new Point(54.396269, 18.573682));
            Trails[0].Path.Add(new Point(54.396157, 18.573419));
            Trails[0].Path.Add(new Point(54.396110, 18.573478));

            //////////////////////// Road to Kfc will be second trail :D

            Trails.Add(new Connection());
            Trails[1].Color = "red";
            Trails[1].Id = 1;
            Trails[1].Description = "Every Monday poor students go there for some food";
            Trails[1].Name = "Burgerogrzmoty KFC";
            Trails[1].Path.Add(new Point(54.396567, 18.574493));
            Trails[1].Path.Add(new Point(54.396234, 18.576797));
            Trails[1].Path.Add(new Point(54.396250, 18.576855));
            Trails[1].Path.Add(new Point(54.395049, 18.578130));
            Trails[1].Path.Add(new Point(54.395168, 18.578796));
            Trails[1].Path.Add(new Point(54.395168, 18.578796));
            Trails[1].Path.Add(new Point(54.394951, 18.579512));
            Trails[1].Path.Add(new Point(54.394851, 18.579476));
            Trails[1].Path.Add(new Point(54.394427, 18.580052));
            Trails[1].Path.Add(new Point(54.394339, 18.579982));

            ///////////////////////// Now Finaly road to Ygrek!

            Trails.Add(new Connection());
            Trails[2].Color = "green";
            Trails[2].Description = "After long and painfull works on project, student go there for beer";
            Trails[2].Name = "Piwne Oko";
            Trails[2].Path.Add(new Point(54.396157, 18.573419));
            Trails[2].Path.Add(new Point(54.396257, 18.573158));
            Trails[2].Path.Add(new Point(54.396260, 18.573036));
            Trails[2].Path.Add(new Point(54.396334, 18.572951));
            Trails[2].Path.Add(new Point(54.396069, 18.572149));
            Trails[2].Path.Add(new Point(54.395930, 18.571766));
            Trails[2].Path.Add(new Point(54.395803, 18.571331));
            Trails[2].Path.Add(new Point(54.395861, 18.571273));
            Trails[2].Path.Add(new Point(54.395916, 18.570889));
            Trails[2].Path.Add(new Point(54.395916, 18.570889));
            Trails[2].Path.Add(new Point(54.394995, 18.569080));
            Trails[2].Path.Add(new Point(54.394840, 18.569100));
            Trails[2].Path.Add(new Point(54.394840, 18.569100));
            Trails[2].Path.Add(new Point(54.394563, 18.569352));
            Trails[2].Path.Add(new Point(54.394362, 18.569519));
            Trails[2].Path.Add(new Point(54.393983, 18.569646));

        }
    }
}