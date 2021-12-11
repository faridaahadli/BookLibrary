using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    interface IRepository<TEntity> where TEntity : class
    {

        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        void Remove(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
