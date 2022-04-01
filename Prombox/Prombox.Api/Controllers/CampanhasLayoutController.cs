using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prombox.Domain.Commands;
using Prombox.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prombox.Service.Utilities;
using System.IO;

namespace Prombox.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize("Bearer")]
    public class CampanhasLayoutController : BaseController
    {
        private const int PAGE_SIZE = 50;
        private readonly ICampanhasLayoutService _service;

        public CampanhasLayoutController(ICampanhasLayoutService service)
        {
            _service = service;
        }

        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost, DisableRequestSizeLimit]
        public ActionResult Post()
        {
            var command = new CampanhaLayoutCreateCommand
            {
                CampanhaId = Convert.ToInt32(Request.Form["campanhaId"]),
                UrlInstagram = Convert.ToString(Request.Form["urlInstagram"]),
                UrlFacebook = Convert.ToString(Request.Form["urlFacebook"]),
                CorFundoSite = Convert.ToString(Request.Form["corFundoSite"]),
                CorBotoes = Convert.ToString(Request.Form["corBotoes"]),
                CorCabecalhoRodape = Convert.ToString(Request.Form["corCabecalhoRodape"])
            };

            foreach (var file in Request.Form.Files)
            {
                var nome = file.Name + Path.GetExtension(file.FileName);
                var caminho = Path.Combine(DiretorioService.GetCaminhoCampanha(command.CampanhaId), nome);

                using (var stream = new FileStream(caminho, FileMode.Create))
                    file.CopyTo(stream);

                if (file.Name == "urlLogo")
                    command.UrlLogo = String.Format("/{0}/{1}", command.CampanhaId, nome);
                else
                if (file.Name == "urlCampanha")
                    command.UrlCampanha = String.Format("/{0}/{1}", command.CampanhaId, nome);
                else
                if (file.Name == "urlRegulamento")
                    command.UrlRegulamento = String.Format("/{0}/{1}", command.CampanhaId, nome);
                else
                if (file.Name == "urlComoParticipar")
                    command.UrlComoParticipar = String.Format("/{0}/{1}", command.CampanhaId, nome);
                else
                if (file.Name == "urlBanner1")
                    command.UrlBanner1 = String.Format("/{0}/{1}", command.CampanhaId, nome);
                else
                if (file.Name == "urlBanner2")
                    command.UrlBanner2 = String.Format("/{0}/{1}", command.CampanhaId, nome);
                else
                if (file.Name == "urlBanner3")
                    command.UrlBanner3 = String.Format("/{0}/{1}", command.CampanhaId, nome);
            }

            var result = _service.Create(command);

            return Result(result);
        }

        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPut, DisableRequestSizeLimit]
        public ActionResult Put()
        {
            var id = Convert.ToInt32(Request.Form["id"]);
            var model = _service.GetById(id);

            var command = model.ToCampanhasLayoutUpdateCommand();
            command.CampanhaId = Convert.ToInt32(Request.Form["campanhaId"]);
            command.UrlInstagram = Convert.ToString(Request.Form["urlInstagram"]);
            command.UrlFacebook = Convert.ToString(Request.Form["urlFacebook"]);
            command.CorFundoSite = Convert.ToString(Request.Form["corFundoSite"]);
            command.CorBotoes = Convert.ToString(Request.Form["corBotoes"]);
            command.CorCabecalhoRodape = Convert.ToString(Request.Form["corCabecalhoRodape"]);

            command.ExcluirUrlLogo = Convert.ToBoolean(Request.Form["excluirUrlLogo"]);
            command.ExcluirUrlCampanha = Convert.ToBoolean(Request.Form["excluirUrlCampanha"]);
            command.ExcluirUrlRegulamento = Convert.ToBoolean(Request.Form["excluirUrlRegulamento"]);
            command.ExcluirUrlComoParticipar = Convert.ToBoolean(Request.Form["excluirUrlComoParticipar"]);
            command.ExcluirUrlBanner1 = Convert.ToBoolean(Request.Form["excluirUrlBanner1"]);
            command.ExcluirUrlBanner2 = Convert.ToBoolean(Request.Form["excluirUrlBanner2"]);
            command.ExcluirUrlBanner3 = Convert.ToBoolean(Request.Form["excluirUrlBanner3"]);

            foreach (var file in Request.Form.Files)
            {
                var nome = file.Name + Path.GetExtension(file.FileName);
                var caminho = Path.Combine(DiretorioService.GetCaminhoCampanha(command.CampanhaId), nome);

                using (var stream = new FileStream(caminho, FileMode.Create))
                    file.CopyTo(stream);

                if (file.Name == "urlLogo")
                    command.UrlLogo = String.Format("/{0}/{1}", command.CampanhaId, nome);
                else
                if (file.Name == "urlCampanha")
                    command.UrlCampanha = String.Format("/{0}/{1}", command.CampanhaId, nome);
                else
                if (file.Name == "urlRegulamento")
                    command.UrlRegulamento = String.Format("/{0}/{1}", command.CampanhaId, nome);
                else
                if (file.Name == "urlComoParticipar")
                    command.UrlComoParticipar = String.Format("/{0}/{1}", command.CampanhaId, nome);
                else
                if (file.Name == "urlBanner1")
                    command.UrlBanner1 = String.Format("/{0}/{1}", command.CampanhaId, nome);
                else
                if (file.Name == "urlBanner2")
                    command.UrlBanner2 = String.Format("/{0}/{1}", command.CampanhaId, nome);
                else
                if (file.Name == "urlBanner3")
                    command.UrlBanner3 = String.Format("/{0}/{1}", command.CampanhaId, nome);
            }

            var result = _service.Update(command);

            return Result(result);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var model = _service.GetById(id);

            if (model == null)
                return NotFound();

            var result = _service.Delete(new CampanhaLayoutDeleteCommand { Id = id });

            return Result(result);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var model = _service.GetById(id);

            if (model == null)
                return NotFound();

            return Result(model.ToJson());
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("campanha")]
        public ActionResult GetByCampanha(int campanhaId)
        {
            var model = _service.GetByCampanhaId(campanhaId);

            if (model == null)
                return Ok(new { });

            return Result(model.ToJson());
        }

        [HttpGet]
        public ActionResult GetAll(int? currentPage = 1)
        {
            int total = 0;
            var result = _service.GetAll((currentPage.Value - 1), PAGE_SIZE, out total);

            return Result(new
            {
                total,
                itens = result.Select(x => x.ToJson())
            });
        }

    }
}