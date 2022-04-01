using System;
using System.Collections.Generic;

namespace Prombox.Domain.Entities
{
    public class Cliente
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
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public UsuarioCliente UsuarioCliente { get; set; }
        public IList<ClienteCampanha> ClientesCampanhas { get; set; }
        public long UsuarioClienteId { get; set; }

        public dynamic ToJson()
        {
            return new
            {
                Id,
                Nome,
                Cpf,
                EmpresaId
            };
        }
    }
}
