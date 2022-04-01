using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Scopes
{
    public static class ClientesScope
    {
        public static List<string> CreateValidate(this Cliente model)
        {
            var errors = new List<string>();

            if (String.IsNullOrEmpty(model.Nome)) errors.Add("Nome requerido.");
            if (String.IsNullOrEmpty(model.Email)) errors.Add("Email requerido.");
            if (String.IsNullOrEmpty(model.Cep)) errors.Add("Cep requerido.");
            if (String.IsNullOrEmpty(model.Cidade)) errors.Add("Cidade requerido.");
            if (String.IsNullOrEmpty(model.Cpf)) errors.Add("Cpf requerido.");
            if (String.IsNullOrEmpty(model.TelPrincipal)) errors.Add("Telefone Principal requerido.");
            if (model.DataNascimento == DateTime.MinValue) errors.Add("Data Nascimento inv�lida.");

            return errors;
        }

        public static List<string> UpdateValidate(this Cliente model)
        {
            var errors = new List<string>();

            if (String.IsNullOrEmpty(model.Nome)) errors.Add("Nome requerido.");
            if (String.IsNullOrEmpty(model.Email)) errors.Add("Email requerido.");
            if (String.IsNullOrEmpty(model.Cep)) errors.Add("Cep requerido.");
            if (String.IsNullOrEmpty(model.Cidade)) errors.Add("Cidade requerido.");
            if (String.IsNullOrEmpty(model.Cpf)) errors.Add("Cpf requerido.");
            if (String.IsNullOrEmpty(model.TelPrincipal)) errors.Add("Telefone Principal requerido.");
            if (model.DataNascimento == DateTime.MinValue) errors.Add("Data Nascimento inv�lida.");

            return errors;
        }
    }
}
