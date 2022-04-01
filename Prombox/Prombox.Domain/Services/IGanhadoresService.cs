using Prombox.Domain.Commands;
using Prombox.Domain.Commands.Results;
using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Services
{
    public interface IGanhadoresService
    {
        GanhadoresCreateCommandResult Create(GanhadoresCreateCommand commnad);
        GanhadoresDeleteCommandResult Delete(GanhadoresDeleteCommand command);
        Ganhador GetById(int id);
        List<Ganhador> GetAll(int campanhaId);
    }
}
