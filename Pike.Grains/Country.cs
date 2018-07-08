using System.Threading.Tasks;
using Orleans;
using Pike.GrainInterfaces;
using System.Collections.Generic;

namespace Pike.Grains
{
    /// <summary>
    /// Grain implementation class Country.
    /// </summary>
    public class Country : Grain, ICountry
    {
        private IEnumerable<IUser> _visted = new List<IUser>();

        public Task<IEnumerable<IUser>> GetVisitors()
        {
            Task.FromResult(_visted);
        }
        public Task AddVisitor(IUser user)
        {
            _visted.Add(user);
            return TaskDone.Done;
        }
    }
}
