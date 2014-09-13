using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvCorporativa.Models
{
    [Table("PLAY_LIST")]
    public class PlayList
    {
        [Column("Id_PlayList")]
        public long Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }

        [Column("Data_Criacao")]
        public DateTime DataCriacao { get; set; }

        [Column("Data_Inicio")]
        public DateTime DataInicio { get; set; }

        [Column("Data_Fim")]
        public DateTime DataFim { get; set; }
        public virtual ICollection<Midia> Midias { get; set; }
    }
}