using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;

namespace TvCorporativa.Models
{
    [Table("PONTO_TV")]
    public class Ponto
    {
        [Column("Id_Ponto")]
        public long Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }

        [ForeignKey("Id_Empresa")]
        public virtual Empresa Empresa { get; set; }

        [ForeignKey("Id_Template")]
        public virtual Template Template { get; set; }
        public virtual ICollection<Feed> Feeds { get; set; }
    }
}