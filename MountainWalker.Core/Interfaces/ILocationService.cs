using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MountainWalker.Core.Models;

namespace MountainWalker.Core.Interfaces
{
    public interface ILocationService
    { 
        Task<string> GetLocation();
    }
}