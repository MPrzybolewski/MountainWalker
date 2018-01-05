using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MountainWalker.Core.Messages;
using MountainWalker.Core.Models;
using MvvmCross.Plugins.Location;

namespace MountainWalker.Core.Interfaces
{
    public interface ILocationService
    {
        Task<Point> GetLocation();
        Point GetCurrentLocation();
        bool GetStateOfJourney();
        void SetStateOfJourney(bool state);
        List<Point> GetReachedPoints();
        void AddReachedPoint(Point point);
        void SetNewList();
        void SetDialogButtonText(string text);
        string GetDialogButtonText();
        void StartFollow();
    }
}