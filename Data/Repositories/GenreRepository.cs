using Core;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }

        public GenreRepository(AppDbContext context) : base(context)
        { }
     
        public async Task<IEnumerable<Genre>> GetTopEntitiesByBook()
        {
            return await appDbContext.Genres.Include(x => x.BookGenres)
               .OrderByDescending(x => x.BookGenres.Where(z => z.IsActive).Count()).Take(5)
               .ToListAsync();
        }
    }
}
