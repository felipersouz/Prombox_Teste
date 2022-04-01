using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prombox.Domain.Commands;
using Prombox.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prombox.Domain.Entities;
using System.Net.Http;
using Prombox.Domain.Commands.Results;

namespace Prombox.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize("Bearer")]
    public class EmpresasController : BaseController
    {
        private const int PAGE_SIZE = 50;
        private readonly IEmpresasService _service;
        private readonly ICurrentUser _currentUser;
        private readonly IHttpClientFactory _clientFactory;

        public EmpresasController(IEmpresasService service, ICurrentUser currentUser, IHttpClientFactory clientFactory)
        {
            _service = service;
            _currentUser = currentUser;
            _clientFactory = clientFactory;
        }

        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost]
        public ActionResult Post([FromBody] EmpresaCreateCommand command)
        {
            if (command == null)
                return BadRequest();

            var erros = ValidateUrls(command);
            EmpresaCreateCommandResult result = null;
            if (erros.Count > 0)
                result = new EmpresaCreateCommandResult { Errors = erros };
            else
                result = _service.Create(command);

            return Result(result);
        }



        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] EmpresaUpdateCommand command)
        {
            if (command == null)
                return BadRequest();

            var model = _service.GetById(id);

            if (model == null)
                return NotFound();

            var erros = ValidateUrls(command);
            EmpresaUpdateCommandResult result = null;
            if (erros.Count > 0)
                result = new EmpresaUpdateCommandResult { Errors = erros };
            else
                result = _service.Update(command);

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

            var result = _service.Delete(new EmpresaDeleteCommand { Id = id });

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
            var empresas = new List<Empresa>();
            if (_currentUser.EmpresaId.HasValue)
            {
                var empresa = _service.GetById(_currentUser.EmpresaId.Value);
                empresas.Add(empresa);
            }
            else
            {
                empresas = _service.GetAll();
            }


            return Result(empresas.Select(x => x.ToJson()));
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
                    x.RazaoSocial,
                    x.Id,
                    x.Cnpj,
                    x.NomeFantasia,
                    x.Ativa
                })
            });
        }

        private List<string> ValidateUrls(EmpresaCreateCommand command)
        {
            var errors = new List<string>();

            if (!String.IsNullOrEmpty(command.UrlFacebook))
                if (!ValidateUrl(command.UrlFacebook))
                    errors.Add("Url Facebook inválida");

            if (!String.IsNullOrEmpty(command.UrlInstagram))
                if (!ValidateUrl(command.UrlInstagram))
                    errors.Add("Url Instagram inválida");

            if (!String.IsNullOrEmpty(command.UrlLinkedin))
                if (!ValidateUrl(command.UrlLinkedin))
                    errors.Add("Url Linkedin inválida");


            if (!String.IsNullOrEmpty(command.UrlSite))
                if (!ValidateUrl(command.UrlSite))
                    errors.Add("Url Site inválida");

            if (!String.IsNullOrEmpty(command.UrlTwitter))
                if (!ValidateUrl(command.UrlTwitter))
                    errors.Add("Url Twitter inválida");


            if (!String.IsNullOrEmpty(command.UrlYoutube))
                if (!ValidateUrl(command.UrlYoutube))
                    errors.Add("Url Youtube inválida");

            return errors;
        }
        private List<string> ValidateUrls(EmpresaUpdateCommand command)
        {
            var errors = new List<string>();

            if (!String.IsNullOrEmpty(command.UrlFacebook))
                if (!ValidateUrl(command.UrlFacebook))
                    errors.Add("Url Facebook inválida");

            if (!String.IsNullOrEmpty(command.UrlInstagram))
                if (!ValidateUrl(command.UrlInstagram))
                    errors.Add("Url Instagram inválida");

            if (!String.IsNullOrEmpty(command.UrlLinkedin))
                if (!ValidateUrl(command.UrlLinkedin))
                    errors.Add("Url Linkedin inválida");


            if (!String.IsNullOrEmpty(command.UrlSite))
                if (!ValidateUrl(command.UrlSite))
                    errors.Add("Url Site inválida");

            if (!String.IsNullOrEmpty(command.UrlTwitter))
                if (!ValidateUrl(command.UrlTwitter))
                    errors.Add("Url Twitter inválida");


            if (!String.IsNullOrEmpty(command.UrlYoutube))
                if (!ValidateUrl(command.UrlYoutube))
                    errors.Add("Url Youtube inválida");

            return errors;
        }
        private bool ValidateUrl(string url)
        {
            try
            {
                if (String.IsNullOrEmpty(url))
                    return false;

                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var client = _clientFactory.CreateClient();
                var response = client.Send(request);

                if (response.IsSuccessStatusCode)
                    return true;

                return false;
            }
            catch
            {
                return false;
            }
        }

    }
}