using Prombox.Domain.Commands;
using Prombox.Domain.Commands.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Services
{
    public interface ILoginService
    {
        AutenticateCommandResult Autenticate(LoginCommand command);
    }
}
