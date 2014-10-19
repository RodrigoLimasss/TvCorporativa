using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvCorporativa.Models
{
    [Table("PLAY_LIST")]
    public class PlayList
    {
        [Column("Id_PlayList")]
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }

        [Column("Data_Criacao")]
        public DateTime DataCriacao { get; set; }

        [Column("Data_Inicio")]
        public DateTime DataInicio { get; set; }

        [NotMapped]
        public TimeSpan HoraInicio { get; set; }

        [Column("Data_Fim")]
        public DateTime DataFim { get; set; }

        [NotMapped]
        public TimeSpan HoraFim { get; set; }

        [Column("Id_Empresa")]
        public int IdEmpresa { get; set; }

        public virtual Empresa Empresa { get; set; }

        public virtual ICollection<Midia> Midias { get; set; }

        public virtual ICollection<Ponto> Pontos { get; set; }
    }
}