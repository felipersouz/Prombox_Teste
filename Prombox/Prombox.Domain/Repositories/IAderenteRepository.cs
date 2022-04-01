using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Repositories
{
    public interface IAderenteRepository
    {
        void Create(Aderente model);
        void Update(Aderente model);
        void Delete(Aderente model);
        Aderente GetById(int id);
        bool IsAssociadoCampanha(string cnpj);

        List<Aderente> GetByCampanha(int campanhaId);
        List<Aderente> GetAll();
        List<Aderente> GetAll(int? empresaId, string nome, int start, int limit, out int total);
    }
}
