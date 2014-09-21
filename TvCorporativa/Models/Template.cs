using System.ComponentModel.DataAnnotations.Schema;

namespace TvCorporativa.Models
{
    public class Template
    {
        [Column("Id_Template")]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Html { get; set; }
    }
}