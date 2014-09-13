using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TvCorporativa.Models;

namespace TvCorporativa.DAL
{
    public class TvContext : DbContext
    {
        public TvContext()
            : base("name=TvCorporativaConection")
        {
            
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Midia> Midias { get; set; }
        public DbSet<Ponto> Pontos { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}