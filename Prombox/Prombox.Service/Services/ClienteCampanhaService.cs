using Prombox.Domain.Entities;
using Prombox.Domain.Repositories;
using Prombox.Domain.Services;
using Prombox.Infra.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Service.Services
{
    public class ClienteCampanhaService : BaseService, IClienteCampanhaService
    {
        private readonly IClienteCampanhaRepository _repository;

        public ClienteCampanhaService(IUnitOfWork uow, IClienteCampanhaRepository repository) : base(uow)
        {
            _repository = repository;
        }

        public void Create(ClienteCampanha model)
        {
            throw new NotImplementedException();
        }

        public void Delete(ClienteCampanha model)
        {
            throw new NotImplementedException();
        }

        public ClienteCampanha Get(long ClienteId, int CampanhaId)
        {
            throw new NotImplementedException();
        }

        public ClienteCampanha GetById(long clienteId, int campanhaId)
        {
            throw new NotImplementedException();
        }

        public void Update(ClienteCampanha model)
        {
            throw new NotImplementedException();
        }
    }
}
