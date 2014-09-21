using System.Collections.Generic;
using System.Linq;
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
            return (from p in Context.Midias
                    where p.IdEmpresa.Equals(empresa.Id)
                    select p).ToList();
        }
    }
}