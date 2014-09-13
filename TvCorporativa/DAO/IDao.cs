using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvCorporativa.DAO
{
    public interface IDao<T> where T : class
    {
        T Save(T entity);
        T SaveColection(IList<T> colection);

        IList<T> GetAll();
        T Get(T entity);
        T Get(int id);
        
        void Delete(T entity);
        void DeleteColection(IList<T> colection);
    }
}
