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
    public class BookRepository : Repository<Book>, IBookRepository
    {

        private AppDbContext appDbContext { get => _context as AppDbContext; }

        public BookRepository(DbContext context) : base(context)
        {}

        public async Task<IEnumerable<Book>> GetBooksByGenre(int genreId)
        {
            return await appDbContext.Books.Include(x => x.BookGenres.Where(z => z.GenreId == genreId))
                .Include(x => x.BookAuthors).ToListAsync();
        }

      
    }
}
