using AutoMapper;
using Importify.Access;
using Importify.Service.Models;

namespace Importify.Service.Logic
{
    /// <summary>
    /// Class for massages logic.
    /// </summary>
    /// <seealso cref="Importify.Service.IMassageUsing" />
    public class MassageUsing : IMassageUsing
    {
        private readonly IMassageAccess _massageAccess;
        private readonly IAuthAccess _authAccess;

        /// <summary>
        /// Initializes a new instance of the <see cref="MassageUsing"/> class.
        /// </summary>
        /// <param name="massageAccess">The massage access.</param>
        /// <param name="authAccess">The authentication access.</param>
        public MassageUsing(IMassageAccess massageAccess, IAuthAccess authAccess)
            => (_massageAccess, _authAccess) = (massageAccess, authAccess);

        /// <inheritdoc/>
        public async Task<int> AddMassageAsync(Massage massage)
        {
            var massageModel = await Maping(massage);

            return await _massageAccess.AddMassageAsync(massageModel);
        }

        /// <inheritdoc/>
        public async Task<int> DeleteMassageAsync(int id)
        {
            return await _massageAccess.DeleteMassageAsync(id);
        }

        /// <inheritdoc/>
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
            var user = await _authAccess.GetUserAsync(massage.User);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Massage, Access.Entities.Massage>()
                                                       .ForMember(ms => ms.User, opt => opt.Ignore()));
            var mapper = new Mapper(config);
            var massageModel = mapper.Map<Access.Entities.Massage>(massage);

            massageModel.User = user;
            return massageModel;
        }
    }
}
