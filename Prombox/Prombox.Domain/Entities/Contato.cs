using Prombox.Domain.Entities.Enum;

namespace Prombox.Domain.Entities
{
    public class Contato
    {
        public int Id { get; set; }
        public ETipoContato TipoContato { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public string Observacoes { get; set; }
        public bool Ativo { get; set; }
        public Empresa Empresa { get; set; }
        public int EmpresaId { get; set; }

        public dynamic ToJson()
        {
            return new
            {
                Id,
                TipoContato,
                Nome,
                Cargo,
                Email,
                Celular,
                Telefone,
                Observacoes,
                Ativo,
                EmpresaId,
                Empresa = Empresa != null ? new { Id = Empresa.Id, NomeFantasia = Empresa.NomeFantasia } : null
            };
        }
    }
}
