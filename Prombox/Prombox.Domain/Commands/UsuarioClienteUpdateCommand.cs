using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Prombox.Domain.Commands
{
    public class UsuarioClienteUpdateCommand : Command
    {
        public long Id { get; set; }
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
        public bool Ativo { get; set; }               

        public UsuarioCliente ToUpdate(UsuarioCliente usuarioCliente, UsuarioClienteUpdateCommand command)
        {            
            usuarioCliente.Email = command.Email;
            usuarioCliente.Cliente.Bairro = command.Bairro;
            usuarioCliente.Cliente.Cep = command.Cep;
            usuarioCliente.Cliente.Cidade = command.Cidade;
            usuarioCliente.Cliente.Complemento = command.Complemento;
            usuarioCliente.Cliente.Cpf = command.Cpf;
            usuarioCliente.Cliente.Email = command.Email;
            usuarioCliente.Cliente.Logradouro = command.Logradouro;
            usuarioCliente.Cliente.Nome = command.Nome;
            usuarioCliente.Cliente.Numero = command.Numero;
            usuarioCliente.Cliente.Rg = command.Rg;
            usuarioCliente.Cliente.TelPrincipal = command.TelPrincipal;
            usuarioCliente.Cliente.TelSecundario = command.TelSecundario;
            usuarioCliente.Cliente.Uf = command.Uf;
            
            return usuarioCliente;
        }
    }
}
