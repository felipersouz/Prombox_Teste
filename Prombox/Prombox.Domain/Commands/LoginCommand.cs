using Prombox.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Commands
{
    public class LoginCommand
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public ETipoUsuario TipoUsuario { get; set; }
        public int? CampanhaId { get; set; }
        public int? EmpresaId { get; set; }

    }
}
