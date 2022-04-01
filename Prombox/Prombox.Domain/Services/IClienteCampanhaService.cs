using Prombox.Domain.Entities;

namespace Prombox.Domain.Services
{
    public interface IClienteCampanhaService
    {
        void Create(ClienteCampanha model);
        void Update(ClienteCampanha model);
        void Delete(ClienteCampanha model);
        ClienteCampanha GetById(long clienteId, int campanhaId);
    }
}
