using Core;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BookService : Service<Book>, IBookService
    {
        public BookService(IUnitOfWork unitOfWork,IRepository<Book> repository)
            :base(unitOfWork,repository)
        {}

        public async Task<IEnumerable<Book>> GetBooksByGenre(int genreId)
        {
            return await _unitOfWork.Books.GetBooksByGenre(genreId);
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _unitOfWork.Books.GetByIdAsync(id);
        }
        
        public Book Update(Book entity)
        {
            var resultEntity = _unitOfWork.Books.Update(entity);

            _unitOfWork.SaveChanges();

            return resultEntity;
        }
    }
}
