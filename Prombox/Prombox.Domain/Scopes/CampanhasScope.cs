using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Scopes
{
    public static class CampanhasScope
    {
        public static List<string> CreateValidate(this Campanha model)
        {
            var errors = new List<string>();

            if (String.IsNullOrEmpty(model.Nome)) errors.Add("Nome requerido.");
            if (model.EmpresaId == 0) errors.Add("EmpresaId requerido.");
            if (model.TipoCampanha == 0) errors.Add("TipoCampanha requerido.");
            //if (model.RegraParticipacao == 0) errors.Add("RegraParticipacao requerido.");

            return errors;
        }

        public static List<string> UpdateValidate(this Campanha model)
        {
            var errors = new List<string>();
            if (String.IsNullOrEmpty(model.Nome)) errors.Add("Nome requerido.");
            if (model.EmpresaId == 0) errors.Add("EmpresaId requerido.");
            if (model.TipoCampanha == 0) errors.Add("TipoCampanha requerido.");
            //if (model.RegraParticipacao == 0) errors.Add("RegraParticipacao requerido.");

            return errors;
        }
    }
}
