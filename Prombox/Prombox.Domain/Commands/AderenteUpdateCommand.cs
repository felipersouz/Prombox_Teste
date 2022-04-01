using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Commands
{
    public class AderenteUpdateCommand : Command
    {
        public bool Ativa { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        private string cnpj;
        public string Cnpj
        {
            get { return !string.IsNullOrEmpty(cnpj) ? cnpj.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "") : null; }
            set { cnpj = value; }
        }
        public int EmpresaId { get; set; }

        public Aderente ToModel(Aderente model)
        {
            model.Id = this.Id;
            model.Nome = this.Nome;
            model.Cnpj = this.Cnpj;
            model.EmpresaId = this.EmpresaId;
            model.Ativa = this.Ativa;

            return model;
        }
    }
}
