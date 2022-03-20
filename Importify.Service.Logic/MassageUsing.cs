using AutoMapper;
using Importify.Access;
using Importify.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importify.Service.Logic
{
    public class MassageUsing : IMassageUsing
    {
        private readonly IMassageAccess _massageAccess;
        private readonly IAuthAccess _authAccess;

        public MassageUsing(IMassageAccess massageAccess, IAuthAccess authAccess)
            => (_massageAccess, _authAccess) = (massageAccess, authAccess);

        public async Task<int> AddMassageAsync(Massage massage)
        {
            var massageModel = await Maping(massage);

            return await _massageAccess.AddMassageAsync(massageModel);
        }

        public async Task<int> DeleteMassageAsync(Massage massage)
        {
            var massageModel = await Maping(massage);

            return await _massageAccess.DeleteMassageAsync(massageModel);
        }

        public async Task<List<Massage>> GetMassagesAsync()
        {
            var massages = await _massageAccess.GetMassagesAsync();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Access.Entities.User, User>().ForMember(us => us.UserInfo, opt => opt.Ignore()).ForMember(us => us.Massages, opt => opt.Ignore()));
            var mapper = new Mapper(config);

            var userModels = massages.Select(us => mapper.Map<User>(us.User)).ToList();


            config = new MapperConfiguration(cfg => cfg.CreateMap<Access.Entities.Massage, Massage>().ForMember(ms => ms.User, opt => opt.Ignore()));
            mapper = new Mapper(config);

            var massageModels = mapper.Map<List<Massage>>(massages);

            for (var i = 0; i < userModels.Count; i++)
                massageModels[i].User = userModels[i].Login;

            return massageModels;
        }

        private async Task<Access.Entities.Massage> Maping(Massage massage)
        {
            var user = await _authAccess.AuthUserAsync(massage.User);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Massage, Access.Entities.Massage>()
                                                       .ForMember(ms => ms.User, opt => opt.Ignore()));
            var mapper = new Mapper(config);
            var massageModel = mapper.Map<Access.Entities.Massage>(massage);

            massageModel.User = user;
            return massageModel;
        }
    }
}
