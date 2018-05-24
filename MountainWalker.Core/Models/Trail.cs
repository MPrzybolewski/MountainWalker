using System;
using System.Collections.Generic;

namespace MountainWalker.Core.Models
{
    public class Trail
    {
        public int Id { get; set; }
        public List<Point> Path { get; private set; }
        private List<string> _polycode;
        public List<string> PolylineCode
        {
            get => _polycode;
            set { _polycode = value; CreatePoints(value); }
        }
        public string Color { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int TimeUp { get; set; }
        public int TimeDown { get; set; }

        public Trail()
        {
            Path = new List<Point>();
        }

        private void CreatePoints(List<string> polyCodes)
        {
            var path = new List<Point>();
            foreach (var code in polyCodes)
            {
                path.AddRange(DecodePolyline(code));
            }
            Path = path;
        }

        private List<Point> DecodePolyline(string encodedPoints)
        {
            if (string.IsNullOrWhiteSpace(encodedPoints))
            {
                return null;
            }

            int index = 0;
            var polylineChars = encodedPoints.ToCharArray();
            var poly = new List<Point>();
            int currentLat = 0;
            int currentLng = 0;
            int next5Bits;

            while (index < polylineChars.Length)
            {
                // calculate next latitude
                int sum = 0;
                int shifter = 0;

                do
                {
                    next5Bits = polylineChars[index++] - 63;
                    sum |= (next5Bits & 31) << shifter;
                    shifter += 5;
                }
                while (next5Bits >= 32 && index < polylineChars.Length);

                if (index >= polylineChars.Length)
                {
                    break;
                }

                currentLat += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                // calculate next longitude
                sum = 0;
                shifter = 0;

                do
                {
                    next5Bits = polylineChars[index++] - 63;
                    sum |= (next5Bits & 31) << shifter;
                    shifter += 5;
                }
                while (next5Bits >= 32 && index < polylineChars.Length);

                if (index >= polylineChars.Length && next5Bits >= 32)
                {
                    break;
                }

                currentLng += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                var mLatLng = new Point(Convert.ToDouble(currentLat) / 100000.0, Convert.ToDouble(currentLng) / 100000.0);
                poly.Add(mLatLng);
            }

            return poly;
        }
    }
}