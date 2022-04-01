using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Commands
{
    public class DuvidaFrequenteCreateCommand : Command
    {
        public string Pergunta { get; set; }
        public string Resposta { get; set; }
        public int Ordem { get; set; }
        public int? EmpresaId { get; set; }
        public int? CampanhaId { get; set; }

        public DuvidaFrequente ToModel()
        {
            var model = new DuvidaFrequente
            {
                Pergunta = this.Pergunta,
                Resposta = this.Resposta,
                Ordem = this.Ordem,
                CampanhaId = this.CampanhaId,
                EmpresaId = this.EmpresaId
            };

            return model;
        }
    }
}
