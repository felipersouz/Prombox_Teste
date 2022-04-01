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
    public class CampanhaLayoutRepository : BaseRepository, ICampanhasLayoutRepository
    {
        public CampanhaLayoutRepository(DataContext context) : base(context)
        {

        }

        public void Create(CampanhaLayout model)
        {
            _context.CampanhasLayout.Add(model);
        }

        public void Update(CampanhaLayout model)
        {
            _context.Entry<CampanhaLayout>(model).State = EntityState.Detached;
            _context.Entry<CampanhaLayout>(model).State = EntityState.Modified;
        }

        public void Delete(CampanhaLayout model)
        {
            _context.Entry<CampanhaLayout>(model).State = EntityState.Deleted;
        }

        public CampanhaLayout GetById(int id)
        {
            return _context.CampanhasLayout.Where(CampanhasLayoutSpacs.GetById(id)).SingleOrDefault();
        }

        public CampanhaLayout GetByCampanhaId(int campanhaId)
        {
            return _context.CampanhasLayout.Where(CampanhasLayoutSpacs.GetByCampanhaId(campanhaId)).SingleOrDefault();
        }

        public List<CampanhaLayout> GetAll()
        {
            return _context.CampanhasLayout.ToList();
        }

        public List<CampanhaLayout> GetAll(int start, int limit, out int total)
        {
            total = _context.CampanhasLayout.Count();

            return _context.CampanhasLayout
                .OrderBy(x => x.Id)
                .Skip(start * limit)
                .Take(limit)
                .ToList();
        }

    }
}
