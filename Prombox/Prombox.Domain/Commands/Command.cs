using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Prombox.Domain.Commands
{
    public class Command
    {
        protected readonly CultureInfo _ptBr = new CultureInfo("pt-BR");

        public string GenerateId()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
