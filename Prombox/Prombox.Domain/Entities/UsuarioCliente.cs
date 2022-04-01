using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prombox.Domain.Entities
{    
    public class UsuarioCliente
    {
        public long Id { get; set; }
        public string Email{ get; set; }
        public DateTime DataCadastro { get; set; }        
        public DateTime? DataPrimeiroAcesso { get; set; }        
        public DateTime? UltimaAlteracaoSenha { get; set; }
        public DateTime? ExpiracaoCodigoRecuperacaoSenha { get; set; }
        public bool Ativo { get; set; }        
        public string CodigoRecuperacaoSenha { get; set; }        
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string Pepper { get; set; } //Fake s� pra dificultar em caso de invas�o        
        public DateTime? BloqueadoAte { get; set; }
        public bool IsExcluido { get; set; }
        public long? UsuarioExclusao { get; set; }
        public DateTime? DataHoraExclusao { get; set; }
        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        
        
        public dynamic ToJson()
        {
            return new
            {
                Id,                
                Email,
                //DataCadastro,
                //DataPrimeiroAcesso,
                //UltimaAlteracaoSenha,
                Ativo,
                //CodigoRecuperacaoSenha,
                //ClienteId,
                Cliente = Cliente?.ToJson(),
                //BloqueadoAte,
                //IsExcluido,
                //UsuarioExclusao,
                //DataHoraExclusao
            };
        }
    }
}
