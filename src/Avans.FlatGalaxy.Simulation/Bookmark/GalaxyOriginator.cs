using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Simulation.Bookmark.Common;

namespace Avans.FlatGalaxy.Simulation.Bookmark
{
    public class GalaxyOriginator : Originator<Galaxy>
    {
        public GalaxyOriginator(Galaxy state) : base(state)
        {
        }
        
        public override IMemento<Galaxy> Save()
        {
            throw new System.NotImplementedException();
        }
    }
}
