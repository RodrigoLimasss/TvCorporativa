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

        //public void Detach(object entity)
        //{
        //    ((IObjectContextAdapter) this).ObjectContext.Detach(entity);
        //}

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Midia> Midias { get; set; }
        public DbSet<PlayList> PlayList { get; set; }
        public DbSet<Ponto> Pontos { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PlayListsPontos> PlayListsPontos { get; set; }
        public DbSet<PlayListsMidias> PlayListsMidias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<PlayList>().HasRequired(x => x.Empresa).WithMany().HasForeignKey(x => x.IdEmpresa);
            modelBuilder.Entity<PlayList>().HasMany(x => x.PlayListsPontos).WithRequired(x => x.PlayList).HasForeignKey(x => x.IdPlayList);
            modelBuilder.Entity<PlayList>().HasMany(x => x.PlayListsMidias).WithRequired(x => x.PlayList).HasForeignKey(x => x.IdPlayList);
            modelBuilder.Entity<PlayListsMidias>().HasKey(x => new { x.IdMidia, x.IdPlayList });
            modelBuilder.Entity<PlayListsPontos>().HasKey(x => new { x.IdPonto, x.IdPlayList });

            modelBuilder.Entity<FeedPonto>().HasKey(x => new {x.IdFeed, x.IdPonto});
            modelBuilder.Entity<Feed>().HasRequired(x => x.Empresa).WithMany().HasForeignKey(x => x.IdEmpresa);
            modelBuilder.Entity<Feed>().HasMany(x => x.FeedsPontos).WithRequired(x => x.Feed).HasForeignKey(x => x.IdFeed);

            modelBuilder.Entity<Midia>().HasRequired(x => x.Empresa).WithMany().HasForeignKey(x => x.IdEmpresa);
            modelBuilder.Entity<Midia>().HasMany(x => x.PlayListsMidias).WithRequired(x => x.Midia).HasForeignKey(x => x.IdMidia);

            modelBuilder.Entity<Ponto>().HasRequired(x => x.Empresa).WithMany().HasForeignKey(x => x.IdEmpresa);
            modelBuilder.Entity<Ponto>().HasRequired(x => x.Template).WithMany().HasForeignKey(x => x.IdTemplate);
            modelBuilder.Entity<Ponto>().HasMany(x => x.PlayListsPontos).WithRequired(x => x.Ponto).HasForeignKey(x => x.IdPonto);
            modelBuilder.Entity<Ponto>().HasMany(x => x.FeedsPontos).WithRequired(x => x.Ponto).HasForeignKey(x => x.IdPonto);
            
            modelBuilder.Entity<Usuario>().HasRequired(x => x.Empresa).WithMany().HasForeignKey(x => x.IdEmpresa);
        }
    }
}