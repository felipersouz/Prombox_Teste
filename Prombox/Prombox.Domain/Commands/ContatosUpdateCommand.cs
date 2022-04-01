using Prombox.Domain.Entities;
using Prombox.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Commands
{
    public class ContatosUpdateCommand : Command
    {
        public int Id { get; set; }
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

        public Contato ToModel(Contato model)
        {
            model.Id = this.Id;
            model.TipoContato = this.TipoContato;
            model.Nome = this.Nome;
            model.Cargo = this.Cargo;
            model.Email = this.Email;
            model.Celular = this.Celular;
            model.Telefone = this.Telefone;
            model.Observacoes = this.Observacoes;
            model.Ativo = this.Ativo;
            model.EmpresaId = this.EmpresaId;

            return model;
        }
    }
}
