using Evot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Generator.Domain.Entities
{
    [Table("UsuariosClientes")]
    public class UsuarioCliente : UsuarioBase
    {
        public dynamic ToJson()
        {            
            return new
            {
                Id,                
                Nome,
                Email,                
                DataCadastro,
                DataPrimeiroAcesso,
                UltimaAlteracaoSenha,
                Ativo,
                CodigoRecuperacaoSenha,
                BloqueadoAte
            };
        }
    }
}
