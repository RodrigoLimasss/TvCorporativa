using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvCorporativa.Models
{
    public class Empresa
    {
        [Column("Id_Empresa")]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeAmigavel { get; set; }

        [Column("Data_Criacao")]
        public DateTime DataCriacao { get; set; }
        public bool Status { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Cnpj { get; set; }
    }
}