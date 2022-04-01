using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Commands
{
    public class NotaFiscalDeleteCommand : Command
    {
        public long Id { get; set; }
    }
}
