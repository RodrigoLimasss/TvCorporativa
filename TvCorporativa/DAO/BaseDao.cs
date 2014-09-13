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
            throw new NotImplementedException();
        }

        public T SaveColection(IList<T> colection)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T Get(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteColection(IList<T> colection)
        {
            throw new NotImplementedException();
        }
    }
}