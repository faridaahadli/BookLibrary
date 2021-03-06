using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class BookGenre
    {

        public int Id { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
