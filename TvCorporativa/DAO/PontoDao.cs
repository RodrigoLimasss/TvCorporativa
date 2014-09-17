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

        public override IList<Ponto> GetAll(Usuario usuario)
        {
            throw new System.NotImplementedException();
        }
    }
}