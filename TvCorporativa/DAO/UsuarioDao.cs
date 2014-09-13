using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TvCorporativa.DAL;
using TvCorporativa.Models;

namespace TvCorporativa.DAO
{
    public class UsuarioDao : BaseDao<Usuario>
    {
        public UsuarioDao(TvContext context) : base(context)
        {
        }
    }
}