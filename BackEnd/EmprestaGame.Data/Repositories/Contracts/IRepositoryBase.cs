using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmprestaGame.Data.Repositories.Contracts
{
    public interface IRepositoryBase<T> where T : EntidadeBase
    {
        void Add(T obj);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetItens(Expression<Func<T, bool>> where = null, Expression<T> orderBy = null);
        T GetItem(int id);
        void Remove(int id);
        void Update(T obj);
        void Dispose();
        T Attach(T obj);
        int Count(Expression<Func<T, bool>> where = null);
        IQueryable<T> Query();
    }
}
