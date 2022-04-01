using Prombox.Domain.Entities;
using Prombox.Domain.Entities.Enum;
using PromboxUtil.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Commands
{
    public class UsuarioCreateCommand : Command
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        private string telefone;
        public string Telefone
        {
             get { return !String.IsNullOrEmpty(telefone) ? telefone.Replace(".", "").Replace("(", "").Replace(")", "").Replace(" ", "") : null; }
            set { telefone = value; }
        }
        public bool Ativo { get; set; }
        public int? EmpresaId { get; set; }
        public int TipoUsuarioId { get; set; }
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }

        public Usuario ToModel()
        {
            var encrypted = !string.IsNullOrEmpty(this.Senha) ? Criptografia.CalcularMD5Hash(this.Senha) : string.Empty;

            var model = new Usuario
            {
                Nome = this.Nome,
                Email = this.Email,
                Telefone = this.Telefone,
                Ativo = this.Ativo,
                EmpresaId = this.EmpresaId,
                TipoUsuario = (ETipoUsuario)this.TipoUsuarioId,
                Senha = encrypted,
                DataCadastro = DateTime.Now
            };

            return model;
        }
    }
}
