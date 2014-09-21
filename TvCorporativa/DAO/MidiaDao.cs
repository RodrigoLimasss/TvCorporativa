using System.Collections.Generic;
using TvCorporativa.DAL;
using TvCorporativa.Models;

namespace TvCorporativa.DAO
{
    public class MidiaDao : BaseDao<Midia>
    {
        public MidiaDao(TvContext context) : base(context)
        {
        }

        public override IList<Midia> GetAll(Empresa empresa)
        {
            throw new System.NotImplementedException();
        }
    }
}