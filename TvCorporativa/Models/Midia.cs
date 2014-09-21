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

        [Column("Id_Empresa")]
        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; private set; }
        public ICollection<PlayList> PlayLists { get; set; }
    }
}