using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Scopes
{
    public static class UsuariosScope
    {
        public static List<string> CreateValidate(this Usuario model)
        {
            var errors = new List<string>();

            if(model.TipoUsuario == Entities.Enum.ETipoUsuario.Cliente && !model.EmpresaId.HasValue) errors.Add("Empresa é requerida.");

            if (String.IsNullOrEmpty(model.Nome)) errors.Add("Nome é requerido.");
            if (!String.IsNullOrEmpty(model.Nome) && model.Nome.Length > 100) errors.Add("Nome é inválido.");

            if (String.IsNullOrEmpty(model.Email)) errors.Add("Email é requerido.");
            if (!String.IsNullOrEmpty(model.Email) && model.Email.Length > 100) errors.Add("Email é inválido.");

            if (!String.IsNullOrEmpty(model.AvatarUrl) && model.AvatarUrl.Length > 255) errors.Add("Avatar é inválido.");

            if (String.IsNullOrEmpty(model.Senha)) errors.Add("Senha é requerido.");

            return errors;
        }

        public static List<string> UpdateValidate(this Usuario model)
        {
            var errors = model.CreateValidate();
            return errors;
        }
    }
}
