using Common.Application.Validation;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.RoleAgg;

internal class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(ShopContext context) : base(context)
    {
    }
}