using System.Threading.Tasks;
using System.Collections;
using Orleans;

namespace PikeGrainInterfaces
{
    /// <summary>
    /// Grain interface ICountry
    /// </summary>
    public interface ICountry : IGrainWithGuidKey
    {
        Task<IEnumerable<IUser>> GetVisitors();
    }
}
