using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Scopes
{
    public static class ContatosScope
    {
        public static List<string> CreateValidate(this Contato model)
        {
            var errors = new List<string>();

            if (String.IsNullOrEmpty(model.Nome)) errors.Add("Nome é requerido.");
            return errors;
        }

        public static List<string> UpdateValidate(this Contato model)
        {
            var errors = model.CreateValidate();
            return errors;
        }
    }
}
