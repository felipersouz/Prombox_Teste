using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Commands
{
    public class AlterarSenhaCommand : Command
    {
        public string SenhaAtual { get; set; }
        public string NovaSenha { get; set; }
        public string ConfirmaNovaSenha { get; set; }
    }
}
