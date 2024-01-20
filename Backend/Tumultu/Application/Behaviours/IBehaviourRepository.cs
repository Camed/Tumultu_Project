using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.Behaviours;

public interface IBehaviourRepository : IBehaviourReadOnlyRepository, IRepository<Behaviour, int>
{
}