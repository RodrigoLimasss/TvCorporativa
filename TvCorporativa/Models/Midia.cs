using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvCorporativa.Models
{
    public class Midia
    {
        [Column("Id_Midia")]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Extensao { get; set; }
        public double Tamanho { get; set; }

        [Column("Id_Usuario")]
        public int IdUsuario { get; set; }
        public virtual ICollection<PlayList> PlayLists { get; set; }
    }
}