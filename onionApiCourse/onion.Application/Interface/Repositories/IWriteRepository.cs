using onion.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion.Application.Interface.Repositories
{
    public interface IWriteRepository<T> where T : class, IEntityBase, new()
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IList<T> entities);
        Task<T> UpdateAsync(T entity);

        //Kaydı komple silmek
        Task HardDeleteAsync(T entity);
        Task HardDeleteRangeAsync(IList<T> entity);
    }
}
