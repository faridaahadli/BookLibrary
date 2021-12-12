using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IRepository<TEntity> _repository;

        public Service(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task AddAsync(TEntity entity)
        {
           await _repository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id); 
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
            _unitOfWork.SaveChanges();
        }

        public TEntity Update(TEntity entity)
        {
             var resultEntity=_repository.Update(entity);

            _unitOfWork.SaveChanges();

            return resultEntity;
        }
    }
}
