using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Commands
{
    public class DuvidaFrequenteUpdateCommand : Command
    {
        public int Id { get; set; }
        public string Pergunta { get; set; }
        public string Resposta { get; set; }
        public int Ordem { get; set; }
        public int? EmpresaId { get; set; }
        public int? CampanhaId { get; set; }

        public DuvidaFrequente ToModel(DuvidaFrequente model)
        {
            model.Id = this.Id;
            model.Pergunta = this.Pergunta;
            model.Resposta = this.Resposta;
            model.Ordem = this.Ordem;
            model.CampanhaId = this.CampanhaId;
            model.EmpresaId = this.EmpresaId;

            return model;
        }
    }
}
