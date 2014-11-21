using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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

        public IList<PlayList> GetPorPonto(int idPonto)
        {
            return (from p in Context.PlayList
                    where p.PlayListsPontos.Any(x => x.IdPonto == idPonto)
                select p).ToList();
        }

        public IList<PlayList> GetPorPontoData(int idPonto)
        {
            return (from p in Context.PlayList
                    where p.PlayListsPontos.Any(x => x.IdPonto == idPonto)
                    && p.Status
                    && p.DataInicio <= DateTime.Now
                    && p.DataFim >= DateTime.Now
                    select p)
                    .OrderBy(p => p.DataInicio)
                    .ToList();
        }

        public void AddPontosAndMidias(PlayList playList, IList<KeyValuePair<int, int>> pontosOrdem, IList<KeyValuePair<int, int>> midiasOrdem)
        {
            var pontos = pontosOrdem.Select(ponto => new PlayListsPontos { Ponto = Context.Pontos.Find(ponto.Key), Ordem = ponto.Value }).ToList();
            var midias = midiasOrdem.Select(midia => new PlayListsMidias { Midia = Context.Midias.Find(midia.Key), Ordem = midia.Value }).ToList();

            playList.ClearPontos();
            playList.ClearMidias();
            playList.AddPontos(pontos);
            playList.AddMidias(midias);
        }
    }
}