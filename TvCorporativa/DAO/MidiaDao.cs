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

        public IList<Midia> GetAll(Empresa empresa, bool orderByDesc)
        {
            var query = (from p in Context.Midias
                         where p.Empresa.Id.Equals(empresa.Id)
                         select p);

            if (orderByDesc)
                query = query.OrderByDescending(p => p.Id);

            return query.ToList();
        }

        public IList<Midia> GetAllNotInPlayList(Empresa empresa, ICollection<PlayListsMidias> playListsMidias)
        {
            string query =
                " SELECT DISTINCT M.Id_Midia AS Id, M.Nome, m.Extensao, M.Tamanho, M.Id_Empresa as IdEmpresa, M.Status " +
                " FROM MIDIA M " +
                " LEFT JOIN PLAYLIST_MIDIA PM ON PM.Id_Midia = M.Id_Midia " +
                " WHERE M.Id_Empresa = " + empresa.Id +
                " AND M.Status = 1 ";
            query += playListsMidias.Any()
                ? " AND M.Id_Midia NOT IN (" + playListsMidias.Select(p => p.Midia.Id.ToString()).Aggregate((a, b) => a + ", " + b) + ") "
                : "";

            return Context.Midias.SqlQuery(query).ToList();
        }
    }
}