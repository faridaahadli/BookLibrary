using Core;
using Core.Repositories;
using Core.UnitOfWork;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private BookRepository _bookRepository;
        private AuthorRepository _authorRepository;
        private GenreRepository _genreRepository;


        public IBookRepository Books => _bookRepository = _bookRepository ?? new BookRepository(_context);
        public IAuthorRepository Authors => _authorRepository = _authorRepository ?? new AuthorRepository(_context);
        public IGenreRepository Genres => _genreRepository = _genreRepository ?? new GenreRepository(_context);


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
