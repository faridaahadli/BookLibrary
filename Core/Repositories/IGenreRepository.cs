using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    interface IGenreRepository:IRepository<Genre>
    {
        Task<IEnumerable<Genre>> GetTopFiveGenre();
    }
}
