using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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

        public virtual ICollection<PlayListsMidias> PlayListsMidias { get; set; }

        public virtual ICollection<PlayListsPontos> PlayListsPontos { get; set; }

        public void AddPontos(IEnumerable<PlayListsPontos> playListsPontos)
        {
            foreach (var playListPonto in playListsPontos)
            {
                if (!PlayListsPontos.Select(x => x.IdPonto).Contains(playListPonto.Ponto.Id))
                    PlayListsPontos.Add(playListPonto);
            }
        }

        public void AddMidias(IEnumerable<PlayListsMidias> playListsMidias)
        {
            foreach (var playListMidia in playListsMidias)
            {
                if (!PlayListsMidias.Select(x => x.IdMidia).Contains(playListMidia.Midia.Id))
                    PlayListsMidias.Add(playListMidia);
            }
        }

        public void ClearPontos()
        {
            PlayListsPontos.Clear();
        }

        public void ClearMidias()
        {
            PlayListsMidias.Clear();
        }
    }
}