using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmprestaGame.Business.Contracts
{
    public interface IBusinessBase<T> where T : EntidadeBase
    {
        void Add(T obj);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetItens(Expression<Func<T, bool>> where = null, Expression<T> orderBy = null);
        T GetItem(int id);
        void Remove(int id);
        void Update(T obj);
        T Attach(T obj);
        int Count(Expression<Func<T, bool>> where = null);
    }
}
