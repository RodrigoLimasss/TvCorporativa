using System.ComponentModel.DataAnnotations.Schema;

namespace TvCorporativa.Models
{
    [Table("FEED_PONTO")]
    public class FeedPonto
    {
        [Column("Id_Feed")]
        public int IdFeed { get; set; }

        [Column("Id_Ponto")]
        public int IdPonto { get; set; }

        public int Ordem { get; set; }
        public virtual Feed Feed { get; set; }
        public virtual Ponto Ponto { get; set; }
    }
}