using System.ComponentModel.DataAnnotations.Schema;

namespace TvCorporativa.Models
{
    [Table("PONTO_PLAYLIST")]
    public class PlayListsPontos
    {
        [Column("Id_Ponto")]
        public int IdPonto { get; set; }

        [Column("Id_PlayList")]
        public int IdPlayList { get; set; }
        public int Ordem { get; set; }
        public virtual Ponto Ponto { get; set; }
        public virtual PlayList PlayList { get; set; }
    }
}