using Tumultu.Domain.Common;

namespace Tumultu.Application.Common.Interfaces
{
    public interface IEnumberable<TEntity> where TEntity : BaseEntity<TKey>
    {
    }
}