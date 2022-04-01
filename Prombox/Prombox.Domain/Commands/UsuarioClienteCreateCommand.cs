using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Prombox.Domain.Commands
{
    public class UsuarioClienteCreateCommand : Command
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string DataNascimento { get; set; }
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
        public string Senha { get; set; }
        public bool Termo1 { get; set; }
        public bool Termo2 { get; set; }
        public bool Termo3 { get; set; }
        public int EmpresaId { get; set; }

        public UsuarioCliente ToUsuarioCliente()
        {
            var model = new UsuarioCliente
            {
                Ativo = true,
                CodigoRecuperacaoSenha = null,
                DataCadastro = DateTime.Now,
                DataPrimeiroAcesso = null,
                Email = this.Email,
                UltimaAlteracaoSenha = null,
                BloqueadoAte = null,
                IsExcluido = false,
                UsuarioExclusao = null,
                DataHoraExclusao = null,
                ClienteId = 0
            };

            return model;
        }

        public Cliente ToCliente()
        {
            DateTime dtNascimento = DateTime.MinValue;
            //try
            //{
            //    dtNascimento = DateTime.ParseExact("24/01/2013", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //}catch(Exception) { }


                var model = new Cliente
            {
                Aceite = true,
                Bairro = this.Bairro,
                Cep = this.Cep,
                Cidade = this.Cidade,
                Complemento = this.Complemento,
                Cpf = this.Cpf,
                DataAceiteRegulamento = DateTime.Now,
                DataNascimento = dtNascimento,
                Email = this.Email,
                Logradouro = this.Logradouro,
                Nome = this.Nome,
                Numero = this.Numero,
                Rg = this.Rg,
                TelPrincipal = this.TelPrincipal,
                TelSecundario = this.TelSecundario,
                Uf = this.Uf,
                EmpresaId = this.EmpresaId
            };

            return model;
        }
    }
}
