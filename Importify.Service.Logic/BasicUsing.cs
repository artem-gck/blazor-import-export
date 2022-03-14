using AutoMapper;
using Importify.Access;
using Importify.Service.Models;
using Importify.Access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importify.Service.Logic
{
    public class BasicUsing : IBasicUsing
    {
        private readonly IBasicAccess _basicAccess;

        public BasicUsing(IBasicAccess basicAccess)
            => _basicAccess = basicAccess;


        public async Task<List<Models.Country>> GetCountriesAsync()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Access.Entities.Country, Models.Country>());
            var mapper = new Mapper(config);

            return mapper.Map<List<Models.Country>>(await _basicAccess.GetCountriesAsync());
        }

        public async Task<List<Models.Year>> GetYearsAsync()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Access.Entities.Year, Models.Year>());
            var mapper = new Mapper(config);

            return mapper.Map<List<Models.Year>>(await _basicAccess.GetYearsAsync());
        }

        public async Task<List<Models.Category>> GetCategoryAsync()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Access.Entities.Category, Models.Category>());
            var mapper = new Mapper(config);

            return mapper.Map<List<Models.Category>>(await _basicAccess.GetCategoryAsync());
        }
    }
}
