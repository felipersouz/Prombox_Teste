using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prombox.Domain.Commands;
using Prombox.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prombox.Web.Controllers;

namespace Prombox.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize("Bearer")]
    public class GanhadoresController : BaseController
    {
        private readonly IGanhadoresService _service;
        private readonly ICurrentUser _currentUser;

        public GanhadoresController(IGanhadoresService service, ICurrentUser currentUser)
        {
            _service = service;
            _currentUser = currentUser;
        }

        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost]
        public ActionResult Post([FromBody] GanhadoresCreateCommand command)
        {
            if (command == null)
                return BadRequest();

            var result = _service.Create(command);

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

            var result = _service.Delete(new GanhadoresDeleteCommand { Id = id });

            return Result(result);
        }

        [HttpGet]
        [Route("all")]
        public ActionResult GetAll(int campanhaId)
        {
            var ganhadores = _service.GetAll(campanhaId);

            return Result(ganhadores.Select(x => x.ToJson()));
        }
    }
}
