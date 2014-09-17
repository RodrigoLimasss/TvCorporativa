using System.Collections.Generic;
using TvCorporativa.DAL;
using TvCorporativa.Models;

namespace TvCorporativa.DAO
{
    public class FeedDao : BaseDao<Feed>
    {
        public FeedDao(TvContext context) : base(context)
        {
        }

        public override IList<Feed> GetAll(Usuario usuario)
        {
            throw new System.NotImplementedException();
        }
    }
}