using onion.Application.Interface.Repositories;
using onion.Domain.Common;

namespace onion.Application.Interface.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();
        Task<int> SaveAsync();
        int Save();

    }
}
