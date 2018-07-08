using System.Threading.Tasks;
using Orleans;

namespace PikeGrainInterfaces
{
    /// <summary>
    /// Grain interface IUser
    /// </summary>
    public interface IUser : IGrainWithGuidKey
    {
        Task Visit(ICountry country);
    }
}
