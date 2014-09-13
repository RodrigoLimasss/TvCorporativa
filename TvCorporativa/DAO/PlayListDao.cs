using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TvCorporativa.DAL;
using TvCorporativa.Models;

namespace TvCorporativa.DAO
{
    public class PlayListDao : BaseDao<PlayList>
    {
        public PlayListDao(TvContext context) : base(context)
        {
        }
    }
}