using System.Threading.Tasks;
using Orleans;
using System.Collections;

namespace Pike.GrainInterfaces
{
    /// <summary>
    /// Grain interface ICountry
    /// </summary>
    public interface ICountry : IGrainWithGuidKey
    {
        Task<IEnumerable<IUser>> GetVisitors();
    }
}
