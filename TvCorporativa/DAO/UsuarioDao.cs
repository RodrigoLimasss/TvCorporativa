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

        public Usuario RetornaUsuario(string email, string senha)
        {
            var query = from u in Context.Usuarios
                where u.Email.Equals(email)
                      && u.Senha.Equals(senha)
                select u;

            return query.FirstOrDefault();
        }
    }
}