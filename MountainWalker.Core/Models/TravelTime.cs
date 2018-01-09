using System;
namespace MountainWalker.Core.Models
{
    public class TravelTime
    {
        private int _houre;
		public int Houre 
        { 
            get { return _houre; }
            set { _houre = value; }
        }

        private int _minute;
        public int Minute
        {
            get { return _minute; }
            set { _minute = value; }
        }

        private int _second;
        public int Second
        {
            get { return _second; }
            set { _second = value; }
        }

        public TravelTime (int houre, int minute, int second)
        {
            _houre = houre;
            _minute = minute;
            _second = second;
        }

        public TravelTime(long second)
        {
            ChangedSecondsToTravelTime(second);
        }

        private void ChangedSecondsToTravelTime(long second)
        {
            Houre = (int)second / 3600;
            second = second % 3600;

            Minute = (int)second / 60;
            second = second % 60;

            Second = (int)second;
        }

        public override string ToString()
        {
            return string.Format("{0}h:{1}m:{2}s", Houre, Minute, Second);
        }

    }
}
