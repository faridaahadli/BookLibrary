using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IBookService:IService<Book>
    {
        Task<IEnumerable<Book>> GetBooksByGenre(int genreId);
    }
}
