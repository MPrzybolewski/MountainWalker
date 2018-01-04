using System.Collections;
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
            Points.Add(new Point(54.400680, 18.576661, "SKM")); //skm
            Points.Add(new Point(54.400810, 18.574563, "Grunwaldzka")); //grunwaldzka
            Points.Add(new Point(54.397705, 18.577010, "przejscie")); //przejscie
            Points.Add(new Point(54.396158, 18.573407, "MFI")); //Mfi kckckc
            Points.Add(new Point(54.394345, 18.579970, "KFC")); //KFC
            Points.Add(new Point(54.394121, 18.569394, "Ygrek")); //Ygrek <3
            Points.Add(new Point(54.416479, 18.596220, "Biedronka")); //biedronka Przymorze
            Points.Add(new Point(54.399406, 18.594162, "Hynka"));
            Points.Add(new Point(54.383162, 18.615251, "Wyspiańskiego"));
            Points.Add(new Point(54.389535, 18.609066, "Galeria Zaspa"));
            Points.Add(new Point(54.361725, 18.642379, "Lodowisko"));
            Points.Add(new Point(54.355569, 18.645688, "Główny"));
        }
    }
}