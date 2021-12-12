using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.DTOs.Author
{
    public class AuthorUpdDto
    {
        [Required]
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
