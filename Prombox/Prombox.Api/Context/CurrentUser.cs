using Microsoft.AspNetCore.Http;
using Prombox.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Prombox.Api.Context
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _accessor;

        public CurrentUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public int Id
        {
            get
            {
                if (_accessor.HttpContext.User == null)
                    return 0;

                if (_accessor.HttpContext.User.Identity == null)
                    return 0;

                var identity = (ClaimsIdentity)_accessor.HttpContext.User.Identity;

                if (identity.Claims == null)
                    return 0;

                var _userId = identity.Claims.Where(x => x.Type == "id").SingleOrDefault();

                return Convert.ToInt32(_userId.Value);
            }
        }

        public int TipoUsuarioId
        {
            get
            {
                if (_accessor.HttpContext.User == null)
                    return 0;

                if (_accessor.HttpContext.User.Identity == null)
                    return 0;

                var identity = (ClaimsIdentity)_accessor.HttpContext.User.Identity;

                if (identity.Claims == null)
                    return 0;

                var _tipoUsuarioId = identity.Claims.Where(x => x.Type == "tipoUsuarioId").SingleOrDefault();

                return Convert.ToInt32(_tipoUsuarioId.Value);
            }
        }

        public int? EmpresaId
        {
            get
            {
                if (_accessor.HttpContext.User == null)
                    return 0;

                if (_accessor.HttpContext.User.Identity == null)
                    return 0;

                var identity = (ClaimsIdentity)_accessor.HttpContext.User.Identity;

                if (identity.Claims == null)
                    return 0;

                var _empresaId = identity.Claims.Where(x => x.Type == "empresaId").SingleOrDefault();

                return _empresaId != null && !string.IsNullOrEmpty(_empresaId.Value) ? Convert.ToInt32(_empresaId.Value) : (int?)null;
            }
        }

    }
}
