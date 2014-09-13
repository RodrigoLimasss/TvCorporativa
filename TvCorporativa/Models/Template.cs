using System.ComponentModel.DataAnnotations.Schema;

namespace TvCorporativa.Models
{
    public class Template
    {
        [Column("Id_Template")]
        public long Id { get; set; }
        public string Nome { get; set; }
    }
}