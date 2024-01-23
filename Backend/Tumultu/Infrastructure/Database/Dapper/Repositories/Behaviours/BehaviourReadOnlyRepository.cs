using Tumultu.Application.Behaviours;
using Tumultu.Domain.Entities;
using Tumultu.Infrastructure.Database.Dapper.Repositories.Common;

namespace Tumultu.Infrastructure.Database.Dapper.Repositories.Behaviours;

internal class BehaviourReadOnlyRepository : DapperRepositoryBase<Behaviour, int>, IBehaviourReadOnlyRepository
{
    public BehaviourReadOnlyRepository(IDbConnectionFactory connectionFactory) 
        : base(connectionFactory)
    {
    }
}