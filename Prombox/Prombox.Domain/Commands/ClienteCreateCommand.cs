using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Commands
{
    public class ClienteCreateCommand : Command
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string TelPrincipal { get; set; }
        public string TelSecundario { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public DateTime? DataAceiteRegulamento { get; set; }
        public bool Aceite { get; set; }

        public Cliente ToModel()
        {
            var model = new Cliente
            {
                Nome = this.Nome,
                Cpf = this.Cpf,
                Rg = this.Rg,
                DataNascimento = this.DataNascimento,
                Email = this.Email,
                TelPrincipal = this.TelPrincipal,
                TelSecundario = this.TelSecundario,
                Cep = this.Cep,
                Logradouro = this.Logradouro,
                Numero = this.Numero,
                Complemento = this.Complemento,
                Bairro = this.Bairro,
                Cidade = this.Cidade,
                Uf = this.Uf,
                DataAceiteRegulamento = this.DataAceiteRegulamento,
                Aceite = this.Aceite
            };

            return model;
        }
    }
}
