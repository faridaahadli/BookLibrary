using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IBookRepository:IRepository<Book>
    {
        Task<IEnumerable<Book>> GetBooksByGenre(int genreId);
        Task<Book> GetByIdAsync(int id); 
        Book Update(Book entity);
    }
}
