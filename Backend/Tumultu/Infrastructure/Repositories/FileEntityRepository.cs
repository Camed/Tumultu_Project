using Tumultu.Application.Files.Repositories;
using Tumultu.Domain.Entities;

namespace Tumultu.Infrastructure.Repositories
{
    public class FileEntityRepository : IFileEntitiesRepository
    {
        private readonly DapperContext _dapperContext;

        public FileEntityRepository(DapperContext context)
        {
            _dapperContext = context;
        }

        public Task<IEnumerable<FileEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FileEntity?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
