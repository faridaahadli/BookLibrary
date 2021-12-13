using Core;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BookRepository : Repository<Book>,IBookRepository
    {

        private AppDbContext appDbContext { get => _context as AppDbContext; }

        public BookRepository(AppDbContext context) : base(context)
        {}

        public IEnumerable<Book> GetBooksByGenre(int genreId)
        {
            var booksGenre = appDbContext.BookGenres
                           .Include(x => x.Book)
                           .ThenInclude(x => x.BookAuthors)
                           .Include(x=>x.Book)
                           .ThenInclude(x=>x.BookGenres)
                           .Where(x => x.GenreId == genreId);

            List<Book> books = new List<Book>();

            booksGenre.ToList().ForEach(x => books.Add(x.Book));
            
             foreach(var item in books)
            {
                item.BookGenres.ToList().ForEach(x => x.Genre = appDbContext.Genres.Find(x.GenreId));
                item.BookAuthors.ToList().ForEach(x => x.Author = appDbContext.Authors.Find(x.AuthorId));
            }
            return books ;

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
                    appDbContext.Entry(item).State = EntityState.Added;
                item.Book = null;

            }

            foreach (var item in entity.BookGenres)
            {
                bool checkForItemExistance = appDbContext.BookGenres
                    .Any(x => x.BookId == entity.Id && x.GenreId == item.GenreId && x.IsActive);

                if (!checkForItemExistance)
                    appDbContext.Entry(item).State = EntityState.Added;
                item.Book = null;
 
            }

           

            return entity;

        }

        //PropertyInfo

        public async Task Remove(int id)
        {
            Book entity = await appDbContext.Books
                .FindAsync(id);

            //in case of generic 
            //PropertyInfo propertyInfo = entity.GetType().GetProperty("IsActive");

            //propertyInfo.SetValue(entity, Convert.ChangeType(false, propertyInfo.PropertyType), null);

            entity.IsActive = false;

            appDbContext.BookAuthors.Where(x => x.BookId == entity.Id)
                 .ToList().ForEach(x => x.IsActive = false);

            appDbContext.BookGenres.Where(x => x.BookId == entity.Id)
                .ToList().ForEach(x => x.IsActive = false);


        }
    }
}
