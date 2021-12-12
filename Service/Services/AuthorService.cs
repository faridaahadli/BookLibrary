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
    public class AuthorService : Service<Author>, IAuthorService
    {
        public AuthorService(IUnitOfWork unitOfWork, IRepository<Author> repository)
            :base(unitOfWork,repository)
        {}

        public async Task<IEnumerable<Author>> GetTopFiveAuthor()
        {
            return await _unitOfWork.Authors.GetTopFiveAuthor();
        }
    }
}
