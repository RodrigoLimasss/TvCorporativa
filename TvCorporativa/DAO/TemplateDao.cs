﻿using System.Collections.Generic;
using TvCorporativa.DAL;
using TvCorporativa.Models;

namespace TvCorporativa.DAO
{
    public class TemplateDao : BaseDao<Template>
    {
        public TemplateDao(TvContext context) : base(context)
        {
        }

        public override IList<Template> GetAll(Usuario usuario)
        {
            throw new System.NotImplementedException();
        }
    }
}