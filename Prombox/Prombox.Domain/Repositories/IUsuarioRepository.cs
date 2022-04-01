using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        void Create(Usuario model);
        void Update(Usuario model);
        void Delete(Usuario model);
        Usuario GetById(long id);
        Usuario GetByEmail(string email);
        List<Usuario> GetAll();
        List<Usuario> GetAll(string nome, int start, int limit, out int total);
        bool ExistsEmail(long id, string email);
    }
}
