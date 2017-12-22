using EmprestaGame.Data.Repositories.Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EmprestaGame.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntidadeBase
    {
        protected DbContext Db;

        public RepositoryBase(DbContext db)
        {
            this.Db = db;
        }

        public void Add(T obj)
        {
            Db.Set<T>().Add(obj);
            Db.SaveChanges();
        }

       
        public IEnumerable<T> GetAll()
        {
            return Db.Set<T>().Where(x => x.Status != 0).AsNoTracking().ToList();
        }

        public IEnumerable<T> GetItens(Expression<Func<T, bool>> where = null, Expression<T> orderBy = null)
        {
            IEnumerable<T> retorno;
            if (where == null)
            {
                retorno = GetItens();
            }
            else
            {
                retorno = Db.Set<T>().AsNoTracking().Where(where);
            }

            if (orderBy != null)
                return retorno.OrderBy(x => orderBy).AsEnumerable<T>();
            else
                return retorno.AsEnumerable<T>();
        }

        public virtual T GetItem(int id)
        {
            return Db.Set<T>().Find(id);
        }

        public void Remove(int id)
        {
            var obj = GetItem(id);

            Db.Set<T>().Remove(obj);
            Db.SaveChanges();
        }

        public void Update(T obj)
        {
            T objAtual = Db.Set<T>().Find(obj.Id);
            if (objAtual == null)
                throw new InvalidOperationException("Erro na tentativa de atualizar um registro inexistente.");

            Db.Entry(objAtual).CurrentValues.SetValues(obj);
            Db.Entry(objAtual).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public T Attach(T obj)
        {
            return Db.Set<T>().Attach(obj);
        }

        public int Count(Expression<Func<T, bool>> where = null)
        {
            if (where != null)
                return Db.Set<T>().AsNoTracking().Where(where).Count();
            else
                return Db.Set<T>().AsNoTracking().Count();
        }

        public IQueryable<T> Query()
        {
            return Db.Set<T>().AsNoTracking();
        }
    }
}