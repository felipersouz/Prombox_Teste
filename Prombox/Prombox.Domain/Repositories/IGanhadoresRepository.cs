using Prombox.Domain.Entities;
using System.Collections.Generic;

namespace Prombox.Domain.Repositories
{
    public interface IGanhadoresRepository
    {
        void Create(Ganhador model);
        void Delete(Ganhador model);
        Ganhador GetById(int id);
        List<Ganhador> GetAll(int clienteId);
        Ganhador GetByNumeroDaSorte(int campanhaId, long numero);
    }
}
