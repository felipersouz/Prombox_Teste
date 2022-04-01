using System;
using System.Collections.Generic;
using System.Linq;

namespace Prombox.Domain.Entities
{
    public class NotaFiscal
    {
        public long Id { get; set; }
        public DateTime DataCompra { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Cod { get; set; }
        public string Cnpj { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Saldo { get; set; }
        public UsuarioCliente UsuarioCliente { get; set; }
        public Campanha Campanha { get; set; }
        public long UsuarioClienteId { get; set; }
        public int CampanhaId { get; set; }
        public List<NumeroDaSorteDetalhe> NumerosDaSorteDetalhes { get; set; }

        public dynamic ToJson()
        {
            return new { 
                Id,
                DataCompra,
                DataCadastro,
                Cod,
                Cnpj,
                ValorTotal,
                Saldo,
                UsuarioClienteId,
                CampanhaId,
                Campanha = Campanha?.ToJson(),
                UsuarioCliente = UsuarioCliente?.ToJson(),
                NumerosDaSorteDetalhes = NumerosDaSorteDetalhes.Select(x=> x.ToJson())
            };
        }
    }
}
