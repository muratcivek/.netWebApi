using Microsoft.EntityFrameworkCore;
using onion.Application.Interface.Repositories;
using onion.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion.Persistance.Repository
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {

        public readonly DbContext dbContext;

        public WriteRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> Table { get => dbContext.Set<T>(); }

        public async Task AddAsync(T Entity)
        {
            await Table.AddAsync(Entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await Table.AddRangeAsync(entities);

        }

        public async Task HardDeleteAsync(T Entity)
        {
            await Task.Run(() => Table.Remove(Entity));
        }

        public async Task HardDeleteRangeAsync(IList<T> Entity)
        {
            await Task.Run(() => Table.RemoveRange(Entity));
        }



        public async Task<T> UpdateAsync(T Entity)
        {
            await Task.Run(() => Table.Update(Entity));
            return Entity;
        }
    }
}