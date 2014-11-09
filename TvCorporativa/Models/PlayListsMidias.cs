using System.ComponentModel.DataAnnotations.Schema;

namespace TvCorporativa.Models
{
    [Table("PLAYLIST_MIDIA")]
    public class PlayListsMidias
    {
        [Column("Id_Midia")]
        public int IdMidia { get; set; }

        [Column("Id_PlayList")]
        public int IdPlayList { get; set; }
        public int Ordem { get; set; }
        public virtual Midia Midia { get; set; }
        public virtual PlayList PlayList { get; set; }
    }
}