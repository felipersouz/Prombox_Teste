using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Prombox.Domain.Commands.Results;
using Prombox.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Prombox.Web.Controllers
{
    public class BaseController : Controller
    {
        protected ActionResult Result(CommandResult commandResult)
        {
            if (commandResult.Errors.Count > 0)
                return BadRequest(commandResult.Errors);

            return Ok(commandResult.ToJson());
        }

        protected ActionResult Result(dynamic value)
        {
            return Ok(value);
        }

        protected string GetUserId()
        {
            Claim _claim = ((ClaimsIdentity)User.Identity).Claims.Where(c => c.Type == "userId").SingleOrDefault();

            if (_claim == null)
                return String.Empty;

            return _claim.Value;
        }
    }
}