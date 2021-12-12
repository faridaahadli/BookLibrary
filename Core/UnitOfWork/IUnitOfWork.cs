using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IBookRepository Books { get; }
        public IAuthorRepository Authors { get; }
        public IGenreRepository Genres { get; }

        Task SaveChangesAsync();
        void SaveChanges();
    }
}
