using Prombox.Domain.Entities;
using Prombox.Domain.Spacs;
using Prombox.Domain.Repositories;
using Prombox.Infra;
using Prombox.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Prombox.Infra.Repositories
{
    public class DuvidsFrequenteRepository : BaseRepository, IDuvidasFrequentesRepository
    {
        public DuvidsFrequenteRepository(DataContext context) : base(context)
        {

        }

        public void Create(DuvidaFrequente model)
        {
            _context.DuvidasFrequentes.Add(model);
        }

        public void Update(DuvidaFrequente model)
        {
            _context.Entry<DuvidaFrequente>(model).State = EntityState.Detached;
            _context.Entry<DuvidaFrequente>(model).State = EntityState.Modified;
        }

        public void Delete(DuvidaFrequente model)
        {
            _context.Entry<DuvidaFrequente>(model).State = EntityState.Deleted;
        }

        public List<DuvidaFrequente> GetByCampanha(int campanhaId)
        {
            return _context.DuvidasFrequentes.Where(DuvidasFrequentesSpacs.GetByCampanha(campanhaId)).OrderBy(x=> x.Ordem).ToList();
        }
        public DuvidaFrequente GetById(int id)
        {
            return _context.DuvidasFrequentes.Where(DuvidasFrequentesSpacs.GetById(id)).SingleOrDefault();
        }

        public List<DuvidaFrequente> GetAll()
        {
            return _context.DuvidasFrequentes.ToList();
        }

        public List<DuvidaFrequente> GetAll(int? empresaId, int? campanhaId, string pergunta, int start, int limit, out int total)
        {
            total = _context.DuvidasFrequentes.Where(DuvidasFrequentesSpacs.GetBy(empresaId, campanhaId, pergunta)).Count();

            return _context.DuvidasFrequentes
                .Include(x => x.Empresa)
                .Include(x => x.Campanha)
                .Where(DuvidasFrequentesSpacs.GetBy(empresaId, campanhaId, pergunta))
                .OrderBy(x => x.Id)
                .Skip(start * limit)
                .Take(limit)
                .ToList();
        }

        public List<DuvidaFrequente> GetDefault()
        {
            return _context.DuvidasFrequentes
                .Include(x => x.Empresa)
                .Where(DuvidasFrequentesSpacs.GetDefault())
                .OrderBy(x => x.Id)
                .ToList();
        }
    }
}
