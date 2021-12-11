using Core;
using Core.Models;
using Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options) {}

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

       protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new AuthorConfiguration());
            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new BookGenreConfiguration());
            builder.ApplyConfiguration(new BookAuthorConfiguration());
        }
    }
}
