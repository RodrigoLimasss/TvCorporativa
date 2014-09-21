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

        [Column("Id_Empresa")]
        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; private set; }
        public ICollection<Ponto> Pontos { get; set; }
    }
}