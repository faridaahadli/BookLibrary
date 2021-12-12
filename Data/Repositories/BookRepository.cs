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

        public BookRepository(AppDbContext context) : base(context)
        {}

        public async Task<IEnumerable<Book>> GetBooksByGenre(int genreId)
        {

            var books = from book in appDbContext.Books
                        from genre in book.BookGenres
                        where genre.GenreId == genreId
                        select book;
            return books;
           // return await appDbContext.Books.Include(x => x.BookGenres.Where(z => z.GenreId == genreId)).ToListAsync();
                
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await appDbContext.Books
                .Include(x =>x.BookGenres).ThenInclude(s=>s.Genre)
                .Include(x => x.BookAuthors).ThenInclude(s => s.Author).FirstOrDefaultAsync(x=>x.Id==id);
        }

        public Book Update(Book entity)
        {
            appDbContext.Entry(entity).State = EntityState.Modified;
          
            foreach(var item in entity.BookAuthors)
            {
                bool checkForItemExistance = appDbContext.BookAuthors
                    .Any(x => x.BookId == entity.Id && x.AuthorId == item.AuthorId && x.IsActive);

                if (!checkForItemExistance)
                    appDbContext.Entry(item).State = EntityState.Modified;

            }

            foreach (var item in entity.BookGenres)
            {
                bool checkForItemExistance = appDbContext.BookGenres
                    .Any(x => x.BookId == entity.Id && x.GenreId == item.GenreId && x.IsActive);

                if (!checkForItemExistance)
                    appDbContext.Entry(item).State = EntityState.Modified;
 
            }


            //appDbContext.BookAuthors
            //    .Where(
            //     x => !entity.BookAuthors.Any(m => m.AuthorId == x.AuthorId));

            //appDbContext.BookGenres
            //    .Where(
            //     x => !entity.BookGenres.Any(m => m.GenreId == x.GenreId));

            return entity;
        }
    }
}
