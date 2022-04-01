namespace Prombox.Domain.Entities
{
    public class DuvidaFrequente
    {
        public int Id { get; set; }
        public string Pergunta { get; set; }
        public string Resposta { get; set; }
        public int Ordem { get; set; }
        public int? EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int? CampanhaId { get; set; }
        public Campanha Campanha { get; set; }

        public dynamic ToJson()
        {
            return new
            {
                Id,
                Pergunta,
                Resposta,
                Ordem,
                EmpresaId,
                CampanhaId,
                Campanha = Campanha != null ? new { Id = Campanha.Id, Nome = Campanha.Nome } : null,
                Empresa = Empresa != null ? new { Id = Empresa.Id, NomeFantasia = Empresa.NomeFantasia } : null
            };
        }

    }
}
