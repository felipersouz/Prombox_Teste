using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Services
{
    public interface INumeroDaSorteService
    {
        NumeroDaSorte EscolherNumeroDaSorte(long clienteId, int campanhaId);
        void Update(NumeroDaSorte model);
        void UpdateDetalhe(NumeroDaSorteDetalhe model);
        void CreateDetalhe(NumeroDaSorteDetalhe model);
        List<NumeroDaSorte> GetMines(long usuarioClienteId, int campanhaId);
    }
}
