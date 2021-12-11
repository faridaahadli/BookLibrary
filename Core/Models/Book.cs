using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
   public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
        public virtual ICollection<BookGenre> BookGenres { get; set; }
    }
}
