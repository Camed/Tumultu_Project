using Tumultu.Application.Behaviours;
using Tumultu.Domain.Entities;
using Tumultu.Infrastructure.Database.EFCore.Repositories.Common;

namespace Tumultu.Infrastructure.Database.EFCore.Repositories.Behaviours;

internal class BehaviourRepository : EfCoreRepositoryBase<Behaviour, int>, IBehaviourRepository
{
    public BehaviourRepository(EfCoreDbContext context) : base(context)
    {
    }
}