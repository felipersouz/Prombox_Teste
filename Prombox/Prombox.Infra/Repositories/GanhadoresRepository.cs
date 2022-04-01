using Microsoft.EntityFrameworkCore;
using Prombox.Domain.Entities;
using Prombox.Domain.Repositories;
using Prombox.Domain.Spacs;
using System.Collections.Generic;
using System.Linq;

namespace Prombox.Infra.Repositories
{
    public class GanhadoresRepository : BaseRepository, IGanhadoresRepository
    {
        public GanhadoresRepository(DataContext context) : base(context)
        {

        }

        public void Create(Ganhador model)
        {
            _context.Ganhadores.Add(model);
        }


        public void Delete(Ganhador model)
        {
            _context.Entry<Ganhador>(model).State = EntityState.Deleted;
        }

        public Ganhador GetById(int id)
        {
            return _context.Ganhadores.Where(GanhadorSpacs.GetById(id)).SingleOrDefault();
        }

        public Ganhador GetByNumeroDaSorte(int campanhaId, long numero)
        {
            return _context.Ganhadores.Where(GanhadorSpacs.GetBy(campanhaId, numero)).SingleOrDefault();
        }

        public List<Ganhador> GetAll(int campanhaId)
        {
            return _context.Ganhadores
                .Include(x => x.NumeroDaSorte)
                .Include(x => x.NumeroDaSorte.Cliente)
                .Where(GanhadorSpacs.GetBy(campanhaId)).ToList();
        }


    }
}
