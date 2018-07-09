using System.Threading.Tasks;
using Orleans;
using System.Collections;
using System.Collections.Generic;

namespace Pike.GrainInterfaces
{
    /// <summary>
    /// Grain interface IUser
    /// </summary>
    public interface IUser : IGrainWithGuidKey
    {
        Task Visit(ICountry country);
        Task<List<ICountry>> GetVistedCountries();
        Task<ICountry> GetLastVisted();
    }
}
