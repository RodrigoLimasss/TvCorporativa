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
        public Empresa Empresa { get; private set; }

        [Column("Id_Template")]
        public int IdTemplate { get; set; }
        public Template Template { get; private set; }
        public ICollection<Feed> Feeds { get; set; }
    }
}