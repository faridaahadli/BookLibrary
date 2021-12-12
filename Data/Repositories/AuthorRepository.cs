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
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }

        public AuthorRepository(AppDbContext context):base(context)
        {}

        public async Task<IEnumerable<Author>> GetTopFiveAuthor()
        {
            return await appDbContext.Authors.Include(x=>x.BookAuthors)
                .OrderByDescending(x=>x.BookAuthors.Where(z=>z.IsActive).Count()).Take(5)  
                .ToListAsync();
        }
    }
}
