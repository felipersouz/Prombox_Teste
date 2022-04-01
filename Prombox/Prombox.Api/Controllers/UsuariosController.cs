using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prombox.Domain.Commands;
using Prombox.Domain.Services;
using Prombox.Service.Utilities;
using Prombox.Web.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Prombox.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize("Bearer")]
    public class UsuariosController : BaseController
    {
        private const int PAGE_SIZE = 50;
        private readonly IUsuariosService _service;
        private readonly ICurrentUser _currentUser;

        public UsuariosController(IUsuariosService service, ICurrentUser currentUser)
        {
            _service = service;
            _currentUser = currentUser;
        }

        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost]
        public ActionResult Post([FromBody] UsuarioCreateCommand command)
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
        public ActionResult Put(long id, [FromBody] UsuarioUpdateCommand command)
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

            var result = _service.Delete(new UsuarioDeleteCommand { Id = id });

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
        [HttpGet("current")]
        public ActionResult GetCurrent()
        {
            var model = _service.GetById(_currentUser.Id);

            if (model == null)
                return NotFound();

            return Result(model.ToJson());
        }


        [HttpGet]
        public ActionResult GetAll(string nome, int? currentPage = 1)
        {
            int total = 0;
            var result = _service.GetAll(nome, (currentPage.Value - 1), PAGE_SIZE, out total);

            return Result(new
            {
                total,
                itens = result.Select(x => new
                {
                    x.Id,
                    x.Nome,
                    x.Telefone,
                    x.Email,
                    x.Ativo,
                    Empresa = x.Empresa != null ? new { Id = x.Empresa.Id, Nome = x.Empresa.NomeFantasia } : null,

                })
            });
        }

        [HttpPut("perfil"), DisableRequestSizeLimit]
        public IActionResult UpdatePerfil()
        {
            try
            {
                var usuarioId = Convert.ToInt32(Request.Form["id"]);
                var usuarioNome = Convert.ToString(Request.Form["nome"]);
                var excluir = Convert.ToBoolean(Request.Form["excluir"]);
                var model = _service.GetById(usuarioId);

                if (model == null)
                    return NotFound();

                var command = model.ToUsuarioUpdateCommand();
                command.Nome = usuarioNome;

                if (Request.Form.Files.Count > 0)
                {
                    var arquivo = Request.Form.Files[0];

                    var nomeThumnail = ImagemService.GerarNomeThumbnail();
                    var caminhoCompletoTemporario = Path.Combine(DiretorioService.GetCaminhoTemporario(), nomeThumnail);
                    var caminhoCompletoAvatar = Path.Combine(DiretorioService.GetCaminhoAvatar(), nomeThumnail);

                    using (var stream = new FileStream(caminhoCompletoTemporario, FileMode.Create))
                        arquivo.CopyTo(stream);

                    ImagemService.GerarThumbnail(96, caminhoCompletoTemporario, caminhoCompletoAvatar);

                    if (!String.IsNullOrEmpty(command.AvatarUrl))
                    {
                        var caminhoCompletoAvatarExcluir = Path.Combine(DiretorioService.GetCaminhoAvatar(), command.AvatarUrl);
                        if (System.IO.File.Exists(caminhoCompletoAvatarExcluir))
                            System.IO.File.Delete(caminhoCompletoAvatarExcluir);
                    }

                    command.AvatarUrl = nomeThumnail;
                }

                if (excluir && !String.IsNullOrEmpty(command.AvatarUrl))
                {
                    var caminhoCompletoAvatarExcluir = Path.Combine(DiretorioService.GetCaminhoAvatar(), command.AvatarUrl);
                    if (System.IO.File.Exists(caminhoCompletoAvatarExcluir))
                        System.IO.File.Delete(caminhoCompletoAvatarExcluir);

                    command.AvatarUrl = null;
                }

                var result = _service.Update(command);

                return Result(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível alterar o perfil.: {ex}");
            }
        }

        [Authorize]
        [HttpPut("alterar-senha")]
        public ActionResult AlterarSenha([FromBody] AlterarSenhaCommand command)
        {
            var erros = _service.AlterarSenha(command);

            if (erros.Count > 0)
                return BadRequest(erros);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("esqueci-senha")]
        public ActionResult EsqueciSenha([FromBody] EsqueciSenhaCommand command)
        {
            var erros = _service.EsqueciSenha(command);

            if (erros.Count > 0)
                return BadRequest(erros);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("recuperar-senha")]
        public ActionResult RecuperarSenha([FromBody] RecuperarSenhaCommand command)
        {
            var errors = _service.RecuperarSenha(command);

            if (errors.Count > 0)
                return BadRequest(errors);

            return Ok();

        }
    }
}
