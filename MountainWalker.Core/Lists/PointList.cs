﻿using System.Collections;
using System.Collections.Generic;
using MountainWalker.Core.Models;

namespace MountainWalker.Core
{

    public class PointList

    {
        public List<Point> Points { get; set; }

        public PointList() //all for main view
        {
            Points = new List<Point>();
            ReadAllPoints();
        }

        private void ReadAllPoints()
        {
            Points.Add(new Point(54.400680, 18.576661,"skm")); //skm
            Points.Add(new Point(54.400810, 18.574563,"grunwaldzka")); //grunwaldzka
            Points.Add(new Point(54.397705, 18.577010,"przejscie")); //przejscie
            Points.Add(new Point(54.396158, 18.573407,"mfi")); //Mfi kckckc
            Points.Add(new Point(54.394345, 18.579970,"kfc")); //KFC
            Points.Add(new Point(54.394121, 18.569394,"Ygrek")); //Ygrek <3
            Points.Add(new Point(54.493153, 18.539298, "Future Office"));
        }
    }
}