using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IAuthorService:IService<Author>,IAuthorGenreService<Author>
    {
    }
}
