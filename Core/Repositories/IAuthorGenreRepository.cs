using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
   public interface IAuthorGenreRepository<TEntity> where TEntity :class
    {
        Task<IEnumerable<TEntity>> GetTopEntitiesByBook();
    }
}
