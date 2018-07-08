using System.Threading.Tasks;
using Orleans;
using Pike.GrainInterfaces;
using System.Collections.Generic;

namespace Pike.Grains
{
    /// <summary>
    /// Grain implementation class User.
    /// </summary>
    public class User : Grain, IUser
    {
        private ICountry _lastVisted;
        private IEnumerable<ICountry> _countries = new List<ICountry>();

        public Task Visit(ICountry country)
        {
            _lastVisted = country;
            _countries.Add(country);
            country.AddVisitor(this);
            return TaskDone.Done;
        }
        public Task<IEnumerable<ICountry>> GetVistedCountries()
        {
            return Task.FromResult(_countries);
        }
        public Task<ICountry> GetLastVisted()
        {
            Task.FromResult(_lastVisted);
        }
    }
}
