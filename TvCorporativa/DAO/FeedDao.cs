using System.Collections.Generic;
using System.Linq;
using TvCorporativa.DAL;
using TvCorporativa.Models;

namespace TvCorporativa.DAO
{
    public class FeedDao : BaseDao<Feed>
    {
        public FeedDao(TvContext context) : base(context)
        {
        }
        public override IList<Feed> GetAll(Empresa empresa)
        {
            return (from p in Context.Feeds
                    where p.IdEmpresa.Equals(empresa.Id)
                    select p).ToList();
        }
    }
}