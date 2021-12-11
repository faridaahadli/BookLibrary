﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
   public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
