using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TvCorporativa.Models
{
    public class Feed
    {
        [Column("Id_Feed")]
        public int Id { get; set; }
        public bool Status { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }

        [Column("Id_Empresa")]
        public int IdEmpresa { get; set; }
        public virtual Empresa Empresa { get; private set; }
        public virtual ICollection<FeedPonto> FeedsPontos { get; set; }

        public void ClearPontos()
        {
            if(FeedsPontos != null && FeedsPontos.Any())
                FeedsPontos.Clear();
        }

        public void AddPontos(List<FeedPonto> feedsPontos)
        {
            foreach (var feedPonto in feedsPontos)
            {
                if(FeedsPontos == null)
                    FeedsPontos = new Collection<FeedPonto>();

                if(!FeedsPontos.Select(x => x.IdPonto).Contains(feedPonto.Ponto.Id))
                    FeedsPontos.Add(feedPonto);
            }
        }
    }
}