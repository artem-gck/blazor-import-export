using AutoMapper;
using Importify.Access;

namespace Importify.Service.Logic
{
    /// <summary>
    /// Class for basic crud.
    /// </summary>
    /// <seealso cref="Importify.Service.IBasicUsing" />
    public class BasicUsing : IBasicUsing
    {
        private readonly IBasicAccess _basicAccess;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicUsing"/> class.
        /// </summary>
        /// <param name="basicAccess">The basic access.</param>
        public BasicUsing(IBasicAccess basicAccess)
            => _basicAccess = basicAccess;

        /// <inheritdoc/>
        public async Task<List<Models.Country>> GetCountriesAsync()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Access.Entities.Country, Models.Country>());
            var mapper = new Mapper(config);

            return mapper.Map<List<Models.Country>>(await _basicAccess.GetCountriesAsync());
        }

        /// <inheritdoc/>
        public async Task<List<Models.Year>> GetYearsAsync()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Access.Entities.Year, Models.Year>());
            var mapper = new Mapper(config);

            return mapper.Map<List<Models.Year>>(await _basicAccess.GetYearsAsync());
        }

        /// <inheritdoc/>
        public async Task<List<Models.Category>> GetCategoryAsync()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Access.Entities.Category, Models.Category>());
            var mapper = new Mapper(config);

            return mapper.Map<List<Models.Category>>(await _basicAccess.GetCategoryAsync());
        }
    }
}
