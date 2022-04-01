using Prombox.Domain.Entities;
using System.Collections.Generic;

namespace Prombox.Domain.Repositories
{
    public interface INumeroDaSorteRepository
    {
        NumeroDaSorte GetById(long id);
        NumeroDaSorte GetBy(long numero, int campanhaId);
        long EscolherNumeroDaSorte(long clienteId, int campanhaId);
        void Update(NumeroDaSorte model);
        List<NumeroDaSorte> GetMines(long clienteId, int campanhaId);
        void UpdateDetalhe(NumeroDaSorteDetalhe model);
        void CreateDetalhe(NumeroDaSorteDetalhe model);
    }
}
