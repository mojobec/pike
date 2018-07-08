using System.Threading.Tasks;
using Orleans;
using System.Collections;

namespace Pike.GrainInterfaces
{
    /// <summary>
    /// Grain interface IUser
    /// </summary>
    public interface IUser : IGrainWithGuidKey
    {
        Task Visit(ICountry country);
        Task<IEnumerable<ICountry>> GetVistedCountries();
        Task<ICountry> GetLastVisted();
    }
}
