using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using TvCorporativa.Annotations;

namespace TvCorporativa.Models
{
    public class Template
    {
        [Column("Id_Template")]
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
        
        [AllowHtml]
        public string Html { get; set; }

        [Column("Id_Empresa")]
        public int IdEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }

        public virtual ICollection<Ponto> Pontos { get; [UsedImplicitly] private set; }
    }
}