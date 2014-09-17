using System.Collections.Generic;

namespace TvCorporativa.DAO
{
    public interface IDao<T> where T : class
    {
        T Save(T entity);
        IList<T> SaveColection(IList<T> colection);

        IList<T> GetAll();
        T Get(int id);
        
        void Delete(T entity);
        void DeleteColection(IList<T> colection);
    }
}
