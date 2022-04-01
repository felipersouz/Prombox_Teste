using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prombox.Domain.Commands;
using Prombox.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Prombox.Service.Utilities;

namespace Prombox.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize("Bearer")]
    public class CampanhasController : BaseController
    {
        private const int PAGE_SIZE = 50;
        private readonly ICampanhasService _service;

        public CampanhasController(ICampanhasService service)
        {
            _service = service;
        }

        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost]
        public ActionResult Post([FromBody] CampanhasCreateCommand command)
        {
            if (command == null)
                return BadRequest();

            var result = _service.Create(command);

            return Result(result);
        }



        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CampanhasUpdateCommand command)
        {
            if (command == null)
                return BadRequest();

            var model = _service.GetById(id);

            if (model == null)
                return NotFound();

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

            var result = _service.Delete(new CampanhaDeleteCommand { Id = id });

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

        [HttpGet]
        [Route("all")]
        public ActionResult GetAll(int empresaId)
        {
            var result = _service.GetAll(empresaId);

            return Result(result.Select(x => x.ToJson()));
        }

        [HttpGet]
        public ActionResult GetAll(int? empresaId, string nome, int? currentPage = 1)
        {
            int total = 0;
            var result = _service.GetAll(empresaId, nome, (currentPage.Value - 1), PAGE_SIZE, out total);

            return Result(new
            {
                total,
                itens = result.Select(x => x.ToJson())
            });
        }

        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPut("UrlGanhadores"), DisableRequestSizeLimit]
        public ActionResult AlterarUrlGanhadores()
        {
            var campanhaId = Convert.ToInt32(Request.Form["campanhaId"]);
            var file = Request.Form.Files[0];
            var campanha = _service.GetById(campanhaId);

            var nome = file.Name + Path.GetExtension(file.FileName);
            var caminho = Path.Combine(DiretorioService.GetCaminhoCampanha(campanhaId), nome);

            using (var stream = new FileStream(caminho, FileMode.Create))
                file.CopyTo(stream);

            campanha.UrlImagemGanhadores = String.Format("/{0}/{1}", campanhaId, nome);

            var command = campanha.ToCampanhasUpdateCommand();
            var result = _service.UpdateUrlImagemGanhadores(command);

            return Result(result);
        }

        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpDelete("UrlGanhadores/{campanhaId}")]
        public ActionResult ExcluirUrlGanhadores(int campanhaId)
        {
            var campanha = _service.GetById(campanhaId);

            if (campanha == null)
                return NotFound();

            if (!String.IsNullOrEmpty(campanha.UrlImagemGanhadores))
            {
                var arquivo = DiretorioService.GetCaminhoCampanha() + campanha.UrlImagemGanhadores;
                if (System.IO.File.Exists(arquivo))
                    System.IO.File.Delete(arquivo);

                campanha.UrlImagemGanhadores = null;
                var command = campanha.ToCampanhasUpdateCommand();
                _service.UpdateUrlImagemGanhadores(command);
            }

            return Ok();
        }


        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPut("aderentes")]
        public ActionResult PutAderentes([FromBody] UpdateAderentesCommand command)
        {
            if (command == null) return BadRequest();

            var result = _service.UpdateAderentes(command);

            return Result(result.Errors);
        }

    }
}