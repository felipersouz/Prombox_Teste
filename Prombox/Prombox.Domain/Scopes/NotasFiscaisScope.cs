using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Scopes
{
    public static class NotasFiscaisScope
    {
        public static List<string> CreateValidate(this NotaFiscal model)
        {
            var errors = new List<string>();

            if (String.IsNullOrEmpty(model.Cod)) errors.Add("Cod requerido.");

            return errors;
        }

        public static List<string> UpdateValidate(this NotaFiscal model)
        {
            var errors = new List<string>();

            if (String.IsNullOrEmpty(model.Cod)) errors.Add("Cod requerido.");

            return errors;
        }
    }
}
