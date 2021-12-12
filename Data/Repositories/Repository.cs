﻿using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }


        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
           return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
           return await _dbSet.FindAsync(id);
        }

        public void Remove(int id)
        {
            var obj=_dbSet.Find(id);

            _dbSet.GetType().GetProperty("IsActive").SetValue(obj, false);
            

        }

        public TEntity Update(TEntity entity)
        {
           _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
