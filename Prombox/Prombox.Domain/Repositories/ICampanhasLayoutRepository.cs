using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Repositories
{
    public interface ICampanhasLayoutRepository
    {
        void Create(CampanhaLayout model);
        void Update(CampanhaLayout model);
        void Delete(CampanhaLayout model);
        CampanhaLayout GetById(int id);
        CampanhaLayout GetByCampanhaId(int id);
        List<CampanhaLayout> GetAll();
        List<CampanhaLayout> GetAll(int start, int limit, out int total);
    }
}
