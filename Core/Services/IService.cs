﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IService<TEntity> where TEntity: class
    {

        Task<TEntity> AddAsync(TEntity entity);
        void Remove(int id);
     
    }
}
