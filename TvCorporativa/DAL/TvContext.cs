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
        public DbSet<PlayList> PlayList { get; set; }
        public DbSet<Ponto> Pontos { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<PlayList>().HasRequired(x => x.Empresa).WithMany().HasForeignKey(x => x.IdEmpresa);
            modelBuilder.Entity<PlayList>().HasMany(x => x.Pontos).WithMany(x => x.PlayLists).Map(c =>
                                                                                                       {
                                                                                                       c.MapLeftKey("Id_PlayList");
                                                                                                       c.MapRightKey("Id_Ponto");
                                                                                                       c.ToTable("PONTO_PLAYLIST");
                                                                                                       });   
            modelBuilder.Entity<Usuario>().HasRequired(x => x.Empresa).WithMany().HasForeignKey(x => x.IdEmpresa);
            modelBuilder.Entity<Feed>().HasRequired(x => x.Empresa).WithMany().HasForeignKey(x => x.IdEmpresa);
            modelBuilder.Entity<Midia>().HasRequired(x => x.Empresa).WithMany().HasForeignKey(x => x.IdEmpresa);
            modelBuilder.Entity<Ponto>().HasRequired(x => x.Empresa).WithMany().HasForeignKey(x => x.IdEmpresa);
            modelBuilder.Entity<Ponto>().HasRequired(x => x.Template).WithMany().HasForeignKey(x => x.IdTemplate);
            //modelBuilder.Entity<Ponto>().HasMany(x => x.PlayLists).WithMany(x => x.Pontos);
        }

    }
}