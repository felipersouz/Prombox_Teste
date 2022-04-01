using Prombox.Domain.Entities;
using Prombox.Domain.Entities.Enum;
using System;

namespace Prombox.Domain.Commands
{
    public class ContatosCreateCommand : Command
    {
        public ETipoContato TipoContato { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        private string celular;
        public string Celular
        {
            get { return !String.IsNullOrEmpty(celular) ? celular.Replace(".", "").Replace("(", "").Replace(")", "").Replace(" ", "") : null; }
            set { celular = value; }
        }
        private string telefone;
        public string Telefone
        {
            get { return !String.IsNullOrEmpty(telefone) ? telefone.Replace(".", "").Replace("(", "").Replace(")", "").Replace(" ", "") : null; }
            set { telefone = value; }
        }
        public string Observacoes { get; set; }
        public bool Ativo { get; set; }
        public int EmpresaId { get; set; }

        public Contato ToModel()
        {
            var model = new Contato
            {
                Nome = this.Nome,
                Cargo = this.Cargo,
                Email = this.Email,
                Celular = this.Celular,
                Telefone = this.Telefone,
                Observacoes = this.Observacoes,
                Ativo = this.Ativo,
                EmpresaId = this.EmpresaId,
                TipoContato = this.TipoContato
            };

            return model;
        }
    }
}
