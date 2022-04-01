using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Commands
{
    public class ClienteUpdateCommand : Command
    {
        public long Id { get; set; }
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

        public Cliente ToModel(Cliente model)
        {
            model.Id = this.Id;
            model.Nome = this.Nome;
            model.Cpf = this.Cpf;
            model.Rg = this.Rg;
            model.DataNascimento = this.DataNascimento;
            model.Email = this.Email;
            model.TelPrincipal = this.TelPrincipal;
            model.TelSecundario = this.TelSecundario;
            model.Cep = this.Cep;
            model.Logradouro = this.Logradouro;
            model.Numero = this.Numero;
            model.Complemento = this.Complemento;
            model.Bairro = this.Bairro;
            model.Cidade = this.Cidade;
            model.Uf = this.Uf;
            model.DataAceiteRegulamento = this.DataAceiteRegulamento;
            model.Aceite = this.Aceite;


            return model;
        }
    }
}
