using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }
    }
}