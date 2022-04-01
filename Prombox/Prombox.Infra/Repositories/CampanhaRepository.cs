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
    public class CampanhaRepository : BaseRepository, ICampanhasRepository
    {
        public CampanhaRepository(DataContext context) : base(context)
        {

        }

        public void Create(Campanha model)
        {
            _context.Campanhas.Add(model);
        }

        public void Update(Campanha model)
        {
            _context.Entry<Campanha>(model).State = EntityState.Detached;
            _context.Entry<Campanha>(model).State = EntityState.Modified;
        }

        public void Delete(Campanha model)
        {
            _context.Entry<Campanha>(model).State = EntityState.Deleted;
        }

        public Campanha GetById(int id)
        {
            return _context.Campanhas
                .Where(CampanhasSpacs.GetById(id))
                .Include(x=>x.CampanhaAderentes)
                .SingleOrDefault();
        }

        public List<Campanha> GetAll(int empresaId)
        {
            return _context.Campanhas.Where(CampanhasSpacs.GetByEmpresaId(empresaId)).ToList();
        }

        public List<Campanha> GetAll(int? empresaId, string nome, int start, int limit, out int total)
        {
            total = _context.Campanhas.Where(CampanhasSpacs.GetBy(empresaId, nome)).Count();

            return _context.Campanhas
                .Include(x => x.Empresa)
                .Where(CampanhasSpacs.GetBy(empresaId, nome))
                .OrderBy(x => x.Id)
                .Skip(start * limit)
                .Take(limit)
                .ToList();
        }

    }
}
