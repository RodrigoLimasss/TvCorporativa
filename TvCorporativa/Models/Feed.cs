using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvCorporativa.Models
{
    public class Feed
    {
        [Column("Id_Feed")]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }

        [Column("Id_Usuario")]
        public int IdUsuario { get; set; }
        public virtual ICollection<Ponto> Pontos { get; set; }
    }
}