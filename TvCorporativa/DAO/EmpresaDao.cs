using System.Collections.Generic;
using System.Linq;
using TvCorporativa.DAL;
using TvCorporativa.Models;

namespace TvCorporativa.DAO
{
    public class EmpresaDao : BaseDao<Empresa>
    {

        public EmpresaDao(TvContext context) : base(context)
        {
        }

        public override IList<Empresa> GetAll(Empresa empresa)
        {
            throw new System.NotImplementedException();
        }
        public IList<Empresa> GetAll(bool orderByDesc)
        {
            var query = (from p in Context.Empresas
                         select p);

            if (orderByDesc)
                query = query.OrderByDescending(p => p.DataCriacao);

            return query.ToList();
        }

        public Empresa GetPorNomeAmigavel(string nome)
        {
            return (from p in Context.Empresas
                where p.NomeAmigavel.Equals(nome)
                select p).FirstOrDefault();
        }
    }
}