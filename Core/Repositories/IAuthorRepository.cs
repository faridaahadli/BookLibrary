﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    interface IAuthorRepository:IRepository<Author>
    {
        Task<IEnumerable<Author>> GetTopFiveAuthor();
    }
}
