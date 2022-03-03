using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Infrastructure.Persistent.Ef.UserAgg
{
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MainContext context) : base(context)
        {
        }
    }
}