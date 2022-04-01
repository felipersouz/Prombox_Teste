using Microsoft.EntityFrameworkCore;
using Prombox.Domain.Entities;
using Prombox.Domain.Repositories;
using Prombox.Domain.Spacs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Infra.Repositories
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        public UsuarioRepository(DataContext context) : base(context)
        {

        }

        public void Create(Usuario model)
        {
            _context.Usuarios.Add(model);
        }

        public void Update(Usuario model)
        {
            _context.Entry<Usuario>(model).State = EntityState.Detached;
            _context.Entry<Usuario>(model).State = EntityState.Modified;
        }

        public void Delete(Usuario model)
        {
            _context.Entry<Usuario>(model).State = EntityState.Deleted;
        }

        public Usuario GetById(long id)
        {
            return _context.Usuarios.Where(UsuariosSpacs.GetById(id)).SingleOrDefault();
        }

        public Usuario GetByEmail(string email)
        {
            return _context.Usuarios.Where(UsuariosSpacs.FilterByEmail(email)).SingleOrDefault();
        }

        public List<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public List<Usuario> GetAll(string nome, int start, int limit, out int total)
        {
            total = _context.Usuarios.Where(UsuariosSpacs.GetByName(nome)).Count();

            return _context.Usuarios
                .Include(x => x.Empresa)
                .Where(UsuariosSpacs.GetByName(nome))
                .OrderBy(x => x.Nome)
                .Skip(start * limit)
                .Take(limit)
                .ToList();
        }

        public bool ExistsEmail(long id, string email)
        {
            return _context.Usuarios.Where(UsuariosSpacs.FilterByEmail(id, email)).Any();
        }
    }
}
