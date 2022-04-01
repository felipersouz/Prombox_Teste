using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Commands
{
    public class RecuperarSenhaCommand
    {
        public int Code { get; set; }
        public string CodeEncrypt { get; set; }
    }
}
