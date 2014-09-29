using System.Collections.Generic;
using System.Linq;
using TvCorporativa.DAL;
using TvCorporativa.Models;

namespace TvCorporativa.DAO
{
    public class PontoDao : BaseDao<Ponto>
    {
        public PontoDao(TvContext context) : base(context)
        {
        }

        public override IList<Ponto> GetAll(Empresa empresa)
        {
            return (from p in Context.Pontos
                where p.Empresa.Id.Equals(empresa.Id)
                select p).ToList();
        }
    }
}