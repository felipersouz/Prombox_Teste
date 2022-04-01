using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Services
{
    public interface ICurrentUser
    {
        public int Id { get; }
        public int TipoUsuarioId { get; }
        public int? EmpresaId { get; }
    }
}
