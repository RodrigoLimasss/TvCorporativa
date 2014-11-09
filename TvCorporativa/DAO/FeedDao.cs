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

        public IList<Feed> GetAll(Empresa empresa, bool orderByDesc)
        {
            var query = (from p in Context.Feeds
                         where p.Empresa.Id.Equals(empresa.Id)
                         select p);

            if (orderByDesc)
                query = query.OrderByDescending(p => p.Id);

            return query.ToList();
        }

        public void AddPontos(Feed feed, List<KeyValuePair<int, int>> pontosOrdem)
        {
            var pontos = pontosOrdem.Select(ponto => new FeedPonto { Ponto = Context.Pontos.Find(ponto.Key), Ordem = ponto.Value }).ToList();

            feed.ClearPontos();
            feed.AddPontos(pontos);
        }
    }
}