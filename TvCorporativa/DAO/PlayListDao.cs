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

        public override IList<PlayList> GetAll(Usuario usuario)
        {
            return (from p in Context.PlayList
                where p.IdUsuario.Equals(usuario.Id)
                select p).ToList();
        }
    }
}