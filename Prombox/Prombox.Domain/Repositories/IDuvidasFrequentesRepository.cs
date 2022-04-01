using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Repositories
{
    public interface IDuvidasFrequentesRepository
    {
        void Create(DuvidaFrequente model);
        void Update(DuvidaFrequente model);
        void Delete(DuvidaFrequente model);
        DuvidaFrequente GetById(int id);
        List<DuvidaFrequente> GetByCampanha(int campanhaId);
        List<DuvidaFrequente> GetAll();
        List<DuvidaFrequente> GetAll(int? empresaId, int? campanhaId, string pergunta, int start, int limit, out int total);
        List<DuvidaFrequente> GetDefault();
    }
}
