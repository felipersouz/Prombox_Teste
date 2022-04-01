using Prombox.Domain.Entities;
using System.Collections.Generic;

namespace Prombox.Domain.Repositories
{
    public interface IContatosRepository
    {
        void Create(Contato model);
        void Update(Contato model);
        void Delete(Contato model);
        Contato GetById(int id);
        List<Contato> GetAll();
        List<Contato> GetAll(int? empresaId, string nome, int start, int limit, out int total);
    }
}
