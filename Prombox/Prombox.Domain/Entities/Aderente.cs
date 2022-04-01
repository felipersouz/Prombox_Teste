using System.Collections.Generic;

namespace Prombox.Domain.Entities
{
    public class Aderente
    {
        public Aderente()
        {
            CampanhaAderentes = new List<CampanhaAderente>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public int EmpresaId{ get; set; }
        public Empresa Empresa { get; set; }
        public List<CampanhaAderente> CampanhaAderentes { get; set; }
        public bool Ativa { get; set; }
        public dynamic ToJson()
        {
            var value = new
            {
                Id,
                Nome,
                Cnpj,
                EmpresaId,
                Empresa = Empresa != null ? new { Id = Empresa.Id, NomeFantasia = Empresa.NomeFantasia } : null,
                Ativa
            };

            return value;
        }
    }
}
