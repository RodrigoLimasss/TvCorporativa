using System;
using System.Collections.Generic;
using System.Linq;
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
            return (from p in Context.Pontos
                where p.Empresa.Id.Equals(empresa.Id)
                select p).ToList();
        }

        public IList<Ponto> GetAll(FiltroPonto filtroPonto)
        {
            var query = (from p in Context.Pontos
                select p);

            if (!string.IsNullOrEmpty(filtroPonto.Nome))
                query = query.Where(x => x.Nome.Equals(filtroPonto.Nome));

            if(filtroPonto.Status)
                query = query.Where(x => x.Status);

            if(filtroPonto.IdEmpresa > 0)
                query = query.Where(x => x.IdEmpresa.Equals(filtroPonto.IdEmpresa));

            return query.ToList();
        }

        public IList<Ponto> GetAllNotInPlayList(Empresa empresa, ICollection<PlayListsPontos> playListsPontos)
        {
            string query = " SELECT DISTINCT p.Id_Ponto as Id, p.Id_Empresa as IdEmpresa, p.Id_Template as IdTemplate, p.Nome, p.Status " +
                           " FROM ponto_tv p " +
                           " LEFT JOIN PONTO_PLAYLIST pp on pp.Id_Ponto = p.Id_Ponto " +
                           " WHERE p.Id_Empresa = " + empresa.Id +
                           " AND p.Status = 1 ";
            query += playListsPontos.Any()
                ? " AND p.Id_Ponto NOT IN (" + playListsPontos.Select(p => p.IdPonto.ToString()).Aggregate((a, b) => a + ", " + b) + ") "
                : "";
                           
            return Context.Pontos.SqlQuery(query).ToList();
        }

    }

    public struct FiltroPonto
    {
        public string Nome { get; set; }
        public bool Status { get; set; }
        public int IdEmpresa { get; set; }
    }
}