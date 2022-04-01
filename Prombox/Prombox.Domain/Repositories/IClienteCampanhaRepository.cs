using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Repositories
{
    public interface IClienteCampanhaRepository
    {
        void Create(ClienteCampanha model);
        void Update(ClienteCampanha model);
        void Delete(ClienteCampanha model);
        ClienteCampanha GetById(long clienteId, int campanhaId);
    }
}
