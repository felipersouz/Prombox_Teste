using Prombox.Domain.Entities;
using Prombox.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Commands
{
    public class UsuarioUpdateCommand : Command
    {
        public long Id { get; set; }
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
        public string AvatarUrl { get; set; }

        public Usuario ToModel(Usuario model)
        {
            model.Nome = this.Nome;
            model.Email = this.Email;
            model.Telefone = this.Telefone;
            model.Ativo = this.Ativo;
            model.EmpresaId = this.EmpresaId;
            model.TipoUsuario = (ETipoUsuario)this.TipoUsuarioId;
            model.AvatarUrl = this.AvatarUrl;

            return model;
        }
    }
}
