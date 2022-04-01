using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prombox.Domain.Commands;
using Prombox.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Prombox.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize("Bearer")]
    public class AderentesController : BaseController
    {
        private const int PAGE_SIZE = 50;
        private readonly IAderenteService _service;

        public AderentesController(IAderenteService service)
        {
            _service = service;
        }

        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost]
        public ActionResult Post([FromBody] AderenteCreateCommand command)
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
        public ActionResult Put(int id, [FromBody] AderenteUpdateCommand command)
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

            var result = _service.Delete(new AderenteDeleteCommand { Id = id });

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
        public ActionResult GetAll()
        {
            var result = _service.GetAll();

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

    }
}