using Evot.Domain.Entities;
using Prombox.Generator.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Generator.Domain.Entities
{
    public class Usuario : UsuarioBase
    {
        // Para usuários que vão acessar o admin
        public int EmpresaId { get;  set; }
        public Empresa Empresa { get; set; }

        public ETipoUsuario TipoUsuario { get; set; }
        public string AvatarUrl { get;  set; }

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
                BloqueadoAte,
                TipoUsuario,
                EmpresaId
            };
        }
    }
}
