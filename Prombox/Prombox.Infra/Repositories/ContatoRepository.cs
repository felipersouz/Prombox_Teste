using Microsoft.EntityFrameworkCore;
using Prombox.Domain.Entities;
using Prombox.Domain.Repositories;
using Prombox.Domain.Spacs;
using System.Collections.Generic;
using System.Linq;

namespace Prombox.Infra.Repositories
{
    public class ContatoRepository : BaseRepository, IContatosRepository
    {
        public ContatoRepository(DataContext context) : base(context)
        {

        }

        public void Create(Contato model)
        {
            _context.Contatos.Add(model);
        }

        public void Update(Contato model)
        {
            _context.Entry<Contato>(model).State = EntityState.Detached;
            _context.Entry<Contato>(model).State = EntityState.Modified;
        }

        public void Delete(Contato model)
        {
            _context.Entry<Contato>(model).State = EntityState.Deleted;
        }

        public Contato GetById(int id)
        {
            return _context.Contatos.Where(ContatosSpacs.GetById(id)).SingleOrDefault();
        }

        public List<Contato> GetAll()
        {
            return _context.Contatos.ToList();
        }

        public List<Contato> GetAll(int? empresaId, string nome, int start, int limit, out int total)
        {
            total = _context.Contatos
                .Where(ContatosSpacs.GetBy(empresaId, nome)).Count();

            return _context.Contatos
                .Include(x => x.Empresa)
                .Where(ContatosSpacs.GetBy(empresaId, nome))
                .OrderBy(x => x.Nome)
                .Skip(start * limit)
                .Take(limit)
                .ToList();
        }

    }
}
