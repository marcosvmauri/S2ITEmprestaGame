using EmprestaGame.Business.Contracts;
using EmprestaGame.Data.Repositories.Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EmprestaGame.Business
{
    public class BusinessBase<T> : IDisposable, IBusinessBase<T> where T : EntidadeBase
    {
        protected readonly IRepositoryBase<T> _repository;

        public BusinessBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public void Add(T obj)
        {
            obj.Status = 1;
            _repository.Add(obj);
        }
        

        public T GetItem(int id)
        {
            return _repository.GetItem(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<T> GetItens(Expression<Func<T, bool>> where = null, Expression<T> orderBy = null)
        {
            return _repository.GetItens(where, orderBy);
        }

        public void Remove(int id)
        {
            var usuario = this.GetItem(id);
            usuario.Status = 0;

            _repository.Update(usuario);
        }

        public void Update(T obj)
        {
            _repository.Update(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public T Attach(T obj)
        {
            return _repository.Attach(obj);
        }

        public int Count(Expression<Func<T, bool>> where = null)
        {
            return _repository.Count(where);
        }
    }
}
