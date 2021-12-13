using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IBookService:IService<Book>
    {
        public IEnumerable<Book> GetBooksByGenre(int genreId);
        public Task<Book> GetByIdAsync(int id);
        public Book Update(Book entity);
        public Task Remove(int id);
    }
}
