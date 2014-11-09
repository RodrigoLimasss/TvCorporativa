using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TvCorporativa.DAL;
using TvCorporativa.Models;

namespace TvCorporativa.DAO
{
    public abstract class BaseDao<T> : IDao<T> where T : class
    {
        protected TvContext Context;

        protected BaseDao(TvContext context)
        {
            Context = context;
        } 

        public T Save(T entity)
        {
            if (Int32.Parse((entity).GetType().GetProperty("Id").GetValue(entity).ToString()) > 0)
            {
                Context.Set<T>().Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                Context.Set<T>().Add(entity);
            }

            Context.SaveChanges();
            return entity;
        }

        public IList<T> SaveColection(IList<T> colection)
        {
            foreach (var entity in colection)
            {
                if (Int32.Parse((entity).GetType().GetProperty("Id").GetValue(entity).ToString()) > 0)
                {
                    Context.Set<T>().Attach(entity);
                    Context.Entry(entity).State = EntityState.Modified;
                }
                else
                {
                    Context.Set<T>().Add(entity);
                }
            }

            Context.SaveChanges();
            return colection;
        }

        public IList<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public abstract IList<T> GetAll(Empresa empresa);

        public T Get(int id)
        {
            var entity = Context.Set<T>().Find(id);
            return entity;
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