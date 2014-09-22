using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvCorporativa.Models
{
    public class Usuario
    {
        [Column("Id_Usuario")]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Status { get; set; }
        public bool Administrador { get; set; }

        [Column("Data_Cadastro")]
        public DateTime DataCadastro { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }

        [Column("Id_Empresa")]
        public int IdEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}