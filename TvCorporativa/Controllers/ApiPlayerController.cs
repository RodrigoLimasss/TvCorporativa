﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using TvCorporativa.DAL;
using TvCorporativa.DAO;

namespace TvCorporativa.Controllers
{
    public class ApiPlayerController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        public string Get(int idPonto)
        {
            var repoPonto = GetServiceHelper.GetService<PontoDao>();
            var ponto = repoPonto.Get(idPonto);
            ponto.Sincronizar = false;
            repoPonto.Save(ponto);

            var playLists = GetServiceHelper.GetService<PlayListDao>()
                .GetPorPontoData(idPonto)
                .Select(p =>
                    new
                    {
                        p.Id,
                        p.Nome,
                        p.DataInicio,
                        p.DataFim,
                        midias = p.PlayListsMidias.Where(m => m.Midia.Status).OrderBy(m => m.Ordem)
                            .Select(m => new {m.IdMidia, m.Ordem, m.Midia.Nome, m.Midia.Extensao})}
                    );

            var newObject = new 
            {
                playLists,
                template = ponto.Template.Html,
                idEmpresa = ponto.Empresa.Id,
                logo = ponto.Empresa.Logo,
                ponto.Empresa.NomeAmigavel
            };
            
            return JsonConvert.SerializeObject(newObject);
        }

        public void Post([FromBody]string value)
        {
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {
        }

        public bool VerificaParaSincronizar(int idPonto)
        {
            try
            {
                var ponto = GetServiceHelper.GetService<PontoDao>().Get(idPonto);

                return ponto.Sincronizar;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}