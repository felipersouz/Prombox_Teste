using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Repositories
{
    public interface ICampanhasRepository
    {
        void Create(Campanha model);
        void Update(Campanha model);
        void Delete(Campanha model);
        Campanha GetById(int id);
        List<Campanha> GetAll(int empresaId);
        List<Campanha> GetAll(int? empresaId, string nome, int start, int limit, out int total);
    }
}
