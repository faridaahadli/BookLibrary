using Core;
using Core.Repositories;
using Core.Services;
using Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GenreService : Service<Genre>, IGenreService
    {
        public GenreService(UnitOfWork unitOfWork, IRepository<Genre> repository)
              : base(unitOfWork, repository)
        { }

        public async Task<IEnumerable<Genre>> GetTopFiveGenre()
        {
            return await _unitOfWork.Genres.GetTopFiveGenres();
        }
    }
}
