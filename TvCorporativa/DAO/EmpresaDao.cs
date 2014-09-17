using System.Collections.Generic;
using TvCorporativa.DAL;
using TvCorporativa.Models;

namespace TvCorporativa.DAO
{
    public class EmpresaDao : BaseDao<Empresa>
    {

        public EmpresaDao(TvContext context) : base(context)
        {
        }

        public override IList<Empresa> GetAll(Usuario usuario)
        {
            throw new System.NotImplementedException();
        }
    }
}