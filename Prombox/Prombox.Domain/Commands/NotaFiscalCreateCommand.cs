using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Commands
{
    public class NotaFiscalCreateCommand : Command
    {
        public string Data { get; set; }
        public string Cod { get; set; }
        public string Cnpj { get; set; }
        public decimal ValorTotal { get; set; }
        public long UsuarioClienteId { get; set; }
        public int CampanhaId { get; set; }
        public DateTime? DT { get; set; }

        public NotaFiscal ToModel()
        {
            var model = new NotaFiscal
            {
                DataCompra = this.DT.Value,
                Cod = this.Cod,
                Cnpj = this.Cnpj,
                ValorTotal = this.ValorTotal,
                UsuarioClienteId = this.UsuarioClienteId,
                CampanhaId = this.CampanhaId,
                Saldo = 0
            };

            return model;
        }
    }
}
