using System.Collections.Generic;
using MountainWalker.Core.Models;
using MountainWalker.Core.Interfaces;

namespace MountainWalker.Core.Services
{
    public class TrailService : ITrailService
    {
        public List<Point> Points { get; set; }
        public List<Trail> Trails { get; set; }

        public TrailService()
        {
            Points = new List<Point>();
            ReadAllPoints();

            Trails = new List<Trail>();
            CreateConnections();
            
        }

        private void ReadAllPoints()
        {
            Points.Add(new Point(54.400680, 18.576661, "skm")); //skm
            Points.Add(new Point(54.400810, 18.574563, "grunwaldzka")); //grunwaldzka
            Points.Add(new Point(54.397705, 18.577010, "przejscie")); //przejscie
            Points.Add(new Point(54.396158, 18.573407, "Mfi")); //Mfi kckckc
            Points.Add(new Point(54.394345, 18.579970, "KFC")); //KFC
            Points.Add(new Point(54.394121, 18.569394, "Ygrek")); //Ygrek <3
            Points.Add(new Point(54.034417, 19.033257, "Malbork")); //Malbork

            //Points.Add(new Point(54.090550, 18.790999, "Misiu")); //xvoxin house
            Points.Add(new Point(54.416570, 18.594687, "Lecha Kaczyńskiego xd"));
            Points.Add(new Point(54.493148, 18.539386, "Jit Solution"));
        }

        private void CreateConnections()
        {

            //////////////////////// Test Trail ////////////////////////
            Trails.Add(new Trail());
            Trails[0].Color = "blue";
            Trails[0].Id = 0;
            Trails[0].Description = "Legendarna droga z SKM na UG";
            Trails[0].Name = "Dolina Alchemii";
            Trails[0].TimeUp = 5;
            Trails[0].TimeDown = 5;
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

            Trails.Add(new Trail());
            Trails[1].Color = "red";
            Trails[1].Id = 1;
            Trails[1].Description = "Co poniedziałek biedni studenci podróżują w to miejsce w poszukiwaniu jedzienia";
            Trails[1].Name = "Burgerogrzmoty KFC";
            Trails[1].TimeUp = 5;
            Trails[1].TimeDown = 5;
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

            Trails.Add(new Trail());
            Trails[2].Color = "green";
            Trails[2].Description = "Po długiej i bolesnej pracy nad projektami, biedni studenci udają się tutaj na piwko";
            Trails[2].Name = "Piwne Oko";
            Trails[2].TimeUp = 5;
            Trails[2].TimeDown = 10;
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