using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TvCorporativa.DAL;

namespace TvCorporativa.DAO
{
    public abstract class BaseDao<T> : IDao<T> where T : class
    {
        protected readonly TvContext Context;

        protected BaseDao(TvContext context)
        {
            Context = context;
        } 

        public T Save(T entity)
        {
            var newEntity = Context.Set<T>().Add(entity);
            Context.SaveChanges();
            return newEntity;
        }

        public IList<T> SaveColection(IList<T> colection)
        {
            var newEntitys = Context.Set<T>().AddRange(colection).ToList();
            Context.SaveChanges();
            return newEntitys;
        }

        public IList<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }

        public void DeleteColection(IList<T> colection)
        {
            Context.Set<T>().RemoveRange(colection);
            Context.SaveChanges();
        }
    }
}