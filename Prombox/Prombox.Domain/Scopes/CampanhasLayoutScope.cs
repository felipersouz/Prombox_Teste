using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Scopes
{
    public static class CampanhasLayoutScope
    {
        public static List<string> CreateValidate(this CampanhaLayout model)
        {
            var errors = new List<string>();

            if (model.CampanhaId == 0) errors.Add("CampanhaId requerido.");

            return errors;
        }

        public static List<string> UpdateValidate(this CampanhaLayout model)
        {
            var errors = new List<string>();

            if (model.CampanhaId == 0) errors.Add("CampanhaId requerido.");

            return errors;
        }
    }
}
