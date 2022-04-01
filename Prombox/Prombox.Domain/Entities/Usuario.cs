using Prombox.Domain.Commands;
using Prombox.Domain.Entities.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prombox.Domain.Entities
{
    public class Usuario
    {
        public long Id { get; set; }
        [MaxLength(70)]
        [Column(TypeName = "VARCHAR")]
        public string Nome { get; set; }
        [MaxLength(70)]
        [Column(TypeName = "VARCHAR")]
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataPrimeiroAcesso { get; set; }
        public DateTime? UltimaAlteracaoSenha { get; set; }
        public bool Ativo { get; set; }
        public int? EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public ETipoUsuario TipoUsuario { get; set; }
        public string AvatarUrl { get; set; }
        public string Senha { get; set; }

        public dynamic ToJson()
        {
            return new
            {
                Id,
                Nome,
                Email,
                Telefone,
                DataCadastro,
                DataPrimeiroAcesso,
                UltimaAlteracaoSenha,
                Ativo,
                EmpresaId,
                TipoUsuarioId = (int)TipoUsuario,
                AvatarUrl = !String.IsNullOrEmpty(AvatarUrl) ? AvatarUrl : "Avatar.png"
            };
        }

        public UsuarioUpdateCommand ToUsuarioUpdateCommand()
        {
            return new UsuarioUpdateCommand
            {
                Id = this.Id,
                Ativo = this.Ativo,
                Email = this.Email,
                EmpresaId = this.EmpresaId,
                Nome = this.Nome,
                Telefone = this.Telefone,
                AvatarUrl = this.AvatarUrl,
                TipoUsuarioId = (int)this.TipoUsuario
            };
        }

    }
}
