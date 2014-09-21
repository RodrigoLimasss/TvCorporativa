using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;

namespace TvCorporativa.Models
{
    [Table("PONTO_TV")]
    public class Ponto
    {
        [Column("Id_Ponto")]
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }

        [Column("Id_Empresa")]
        public int IdEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }

        [Column("Id_Template")]
        public int IdTemplate { get; set; }
        public virtual Template Template { get; set; }
        public virtual ICollection<Feed> Feeds { get; set; }
    }
}