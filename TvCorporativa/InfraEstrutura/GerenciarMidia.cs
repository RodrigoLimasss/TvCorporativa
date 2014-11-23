using System.IO;
using System.Web;
using TvCorporativa.DAL;
using TvCorporativa.DAO;
using TvCorporativa.Models;

namespace TvCorporativa.InfraEstrutura
{
    public static class GerenciarMidia
    {
        public static Midia SalvarMidia(HttpPostedFile file, Empresa empresa)
        {
           var newMidia = new Midia
            {
                IdEmpresa = empresa.Id,
                Nome = Path.GetFileNameWithoutExtension(file.FileName).Replace(" ", "_"),
                Status = true,
                Extensao = Path.GetExtension(file.FileName),
                Tamanho = file.ContentLength
            };

            var midia = GetServiceHelper.GetService<MidiaDao>().Save(newMidia);
            midia.Nome = string.Format("{0}_{1}", midia.Nome, midia.Id);

            return GetServiceHelper.GetService<MidiaDao>().Save(newMidia);
        }

        public static void DeletarMidia(int idMidia)
        {
            var repoMidia = GetServiceHelper.GetService<MidiaDao>();
            var midia = repoMidia.Get(idMidia);
            repoMidia.Delete(midia);
        }

        public static void DeletarMidiaDirectory(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static void DeletarMidiaDirectory(string fileName, int idEmpresa)
        {
            var filePath = RetornaPath(idEmpresa) + fileName;

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        private static string RetornaPath(int idEmpresa)
        {
            return Path.Combine(HttpContext.Current.Server.MapPath(string.Format("~/Files/{0}/", idEmpresa)));
        }
    }
}