using Tumultu.Application.Behaviours;
using Tumultu.Domain.Entities;
using Tumultu.Infrastructure.DataProviders.EFCore.Common;

namespace Tumultu.Infrastructure.DataProviders.EFCore.Behaviours;

internal class BehaviourRepository : EfCoreRepositoryBase<Behaviour, int>, IBehaviourRepository
{
    public BehaviourRepository(EfCoreDbContext context) : base(context)
    {
    }
}