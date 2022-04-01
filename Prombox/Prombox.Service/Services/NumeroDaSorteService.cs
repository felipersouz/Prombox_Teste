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
    public class NumeroDaSorteService : BaseService, INumeroDaSorteService
    {
        private readonly INumeroDaSorteRepository _repository;
        private readonly IUsuariosClientesRepository _usuarioClienteRepository;

        public NumeroDaSorteService(
            IUnitOfWork uow, 
            INumeroDaSorteRepository repository,
            IUsuariosClientesRepository usuarioClienteRepository
            ) : base(uow)
        {
            _usuarioClienteRepository = usuarioClienteRepository;
            _repository = repository;
        }

        public decimal GetSaldo()
        {
            throw new NotImplementedException();
        }

        public NumeroDaSorte EscolherNumeroDaSorte(long clienteId, int campanhaId)
        {
            var id = _repository.EscolherNumeroDaSorte(clienteId, campanhaId);
            return _repository.GetById(id);
        }

        public void Update(NumeroDaSorte model)
        {
            _repository.Update(model);
            Commit();
        }

        public void UpdateDetalhe(NumeroDaSorteDetalhe model)
        {
            _repository.UpdateDetalhe(model);
            Commit();
        }

        public void CreateDetalhe(NumeroDaSorteDetalhe model)
        {
            _repository.CreateDetalhe(model);
            Commit();
        }

        public List<NumeroDaSorte> GetMines(long usuarioClienteId, int campanhaId)
        {
            var usuarioCliente = _usuarioClienteRepository.GetById(usuarioClienteId);

            return _repository.GetMines(usuarioCliente.ClienteId, campanhaId);
        }
    }
}
