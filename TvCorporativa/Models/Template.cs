using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace TvCorporativa.Models
{
    public class Template
    {
        [Column("Id_Template")]
        public int Id { get; set; }
        public string Nome { get; set; }
        
        [AllowHtml]
        public string Html { get; set; }
    }
}