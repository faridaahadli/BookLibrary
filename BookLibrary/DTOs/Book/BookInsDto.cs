using BookLibrary.DTOs.Author;
using BookLibrary.DTOs.Genre;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.DTOs
{
    public class BookInsDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<AuthorUpdDto> BookAuthors { get; set; }
        public ICollection<GenreUpdDto> BookGenres { get; set; }
    }
}
