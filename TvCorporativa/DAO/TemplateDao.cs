using System.Collections.Generic;
using System.Linq;
using TvCorporativa.DAL;
using TvCorporativa.Models;

namespace TvCorporativa.DAO
{
    public class TemplateDao : BaseDao<Template>
    {
        public TemplateDao(TvContext context) : base(context)
        {
        }

        public override IList<Template> GetAll(Empresa empresa)
        {
            return (from p in Context.Templates
                where p.Empresa.Id == empresa.Id
                select p).ToList();
        }

    }
}