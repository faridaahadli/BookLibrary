﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
  public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);      
    }
}
