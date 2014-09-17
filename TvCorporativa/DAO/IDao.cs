using System.Collections.Generic;
using TvCorporativa.Models;

namespace TvCorporativa.DAO
{
    public interface IDao<T> where T : class
    {
        T Save(T entity);
        IList<T> SaveColection(IList<T> colection);

        IList<T> GetAll();
        IList<T> GetAll(Usuario usuario);
        T Get(int id);
        
        void Delete(T entity);
        void DeleteColection(IList<T> colection);
    }
}
