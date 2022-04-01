using Microsoft.EntityFrameworkCore;
using Prombox.Domain.Entities;
using Prombox.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Infra.Repositories
{
    public class ClienteCampanhaRepository : BaseRepository, IClienteCampanhaRepository
    {
        public ClienteCampanhaRepository(DataContext context) : base(context)
        {
        }
        public void Create(ClienteCampanha model)
        {
            _context.ClientesCampanhas.Add(model);
        }

        public void Update(ClienteCampanha model)
        {
            _context.Entry<ClienteCampanha>(model).State = EntityState.Detached;
            _context.Entry<ClienteCampanha>(model).State = EntityState.Modified;
        }

        public void Delete(ClienteCampanha model)
        {
            _context.Entry<ClienteCampanha>(model).State = EntityState.Deleted;
        }

        public ClienteCampanha GetById(long clienteId, int campanhaId)
        {
            return _context.ClientesCampanhas
                .Where(x=> x.ClienteId == clienteId && x.CampanhaId == campanhaId)                            
                .SingleOrDefault();
        }
    }
}
