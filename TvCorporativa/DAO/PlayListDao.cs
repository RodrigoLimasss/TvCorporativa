using System.Collections.Generic;
using System.Linq;
using TvCorporativa.DAL;
using TvCorporativa.Models;

namespace TvCorporativa.DAO
{
    public class PlayListDao : BaseDao<PlayList>
    {
        public PlayListDao(TvContext context) : base(context)
        {
        }

        public override IList<PlayList> GetAll(Empresa empresa)
        {
            return (from p in Context.PlayList
                where p.Empresa.Id.Equals(empresa.Id)
                select p).ToList();
        }

        public IList<PlayList> GetAll(Empresa empresa, bool orderByDesc)
        {
            var query = (from p in Context.PlayList
                    where p.Empresa.Id.Equals(empresa.Id)
                    select p);

            if (orderByDesc)
                query = query.OrderByDescending(p => p.DataCriacao);

            return query.ToList();
        }
    }
}