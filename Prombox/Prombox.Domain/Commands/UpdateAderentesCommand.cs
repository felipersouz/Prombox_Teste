using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Commands
{
    public class UpdateAderentesCommand
    {
        public UpdateAderentesCommand()
        {
            Aderentes = new List<UpdateAderenteCommand>();
        }

        public int CampanhaId { get; set; }

        public List<UpdateAderenteCommand> Aderentes { get; set; }
    }
}
