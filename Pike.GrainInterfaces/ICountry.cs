using System.Threading.Tasks;
using Orleans;
using System.Collections;
using System.Collections.Generic;

namespace Pike.GrainInterfaces
{
    /// <summary>
    /// Grain interface ICountry
    /// </summary>
    public interface ICountry : IGrainWithGuidKey
    {
        Task<IEnumerable<IUser>> GetVisitors();
        Task AddVisitor(IUser user);
    }
}
