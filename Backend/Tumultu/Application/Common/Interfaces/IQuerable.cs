using Tumultu.Domain.Common;

namespace Tumultu.Application.Common.Interfaces
{
    public interface IQuerable<TEntity> where TEntity : BaseEntity<TKey>
    {
    }
}