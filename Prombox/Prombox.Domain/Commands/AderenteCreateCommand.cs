using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Commands
{
    public class AderenteCreateCommand : Command
    {
        public bool Ativa { get; set; }
        public string Nome { get; set; }
        private string cnpj;
        public string Cnpj
        {
            get { return !string.IsNullOrEmpty(cnpj) ? cnpj.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "") : null; }
            set { cnpj = value; }
        }
        public int EmpresaId { get; set; }

        public Aderente ToModel()
        {
            var model = new Aderente
            {
                Nome = this.Nome,
                Cnpj = this.Cnpj,
                EmpresaId = this.EmpresaId,
                Ativa = this.Ativa
            };

            return model;
        }
    }
}