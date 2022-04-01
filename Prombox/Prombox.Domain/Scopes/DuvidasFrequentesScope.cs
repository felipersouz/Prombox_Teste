using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Scopes
{
    public static class DuvidasFrequentesScope
    {
        public static List<string> CreateValidate(this DuvidaFrequente model)
        {
            var errors = new List<string>();

            if (String.IsNullOrEmpty(model.Pergunta)) errors.Add("Pergunta requerido.");
            if (!String.IsNullOrEmpty(model.Pergunta) && model.Pergunta.Length > 255) errors.Add("Pergunta é inválido.");

            if (String.IsNullOrEmpty(model.Resposta)) errors.Add("Resposta requerido.");
            if (!String.IsNullOrEmpty(model.Resposta) && model.Resposta.Length > 2000) errors.Add("Resposta é inválido.");

            return errors;
        }

        public static List<string> UpdateValidate(this DuvidaFrequente model)
        {
            return CreateValidate(model);
        }
    }
}
