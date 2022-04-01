using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Commands
{
    public class NotaFiscalUpdateCommand : Command
    {
        public long Id { get; set; }
        public DateTime Data { get; set; }
        public string Cod { get; set; }
        public string Cnpj { get; set; }
        public decimal ValorTotal { get; set; }

        public NotaFiscal ToModel(NotaFiscal model)
        {
            model.Id = this.Id;
            model.DataCompra = this.Data;
            model.Cod = this.Cod;
            model.Cnpj = this.Cnpj;
            model.ValorTotal = this.ValorTotal;


            return model;
        }
    }
}
