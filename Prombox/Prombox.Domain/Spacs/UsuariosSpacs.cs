using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Spacs
{
    public class UsuariosSpacs
    {
        public static Expression<Func<Usuario, bool>> GetById(long id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<Usuario, bool>> GetByName(string name)
        {
            if (string.IsNullOrEmpty(name)) name = String.Empty;

            return x => x.Nome.Contains(name);
        }

        public static Expression<Func<Usuario, bool>> FilterByEmail(long id, string email)
        {
            return x => x.Id != id && x.Email.ToUpper() == email.ToUpper();
        }

        public static Expression<Func<Usuario, bool>> FilterByEmail(string email)
        {
            return x => x.Email.ToUpper() == email.ToUpper();
        }
    }
}
