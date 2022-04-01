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
    public class NotasFiscaisController : BaseController
    {
        private const int PAGE_SIZE = 50;
        private readonly INotasFiscaisService _service;

        public NotasFiscaisController(INotasFiscaisService service)
        {
            _service = service;
        }

        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost]
        public ActionResult Post([FromBody] NotaFiscalCreateCommand command)
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
        public ActionResult Put(long id, [FromBody] NotaFiscalUpdateCommand command)
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
        public ActionResult Delete(long id)
        {
            var model = _service.GetById(id);

            if (model == null)
                return NotFound();

            var result = _service.Delete(new NotaFiscalDeleteCommand { Id = id });

            return Result(result);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public ActionResult Get(long id)
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