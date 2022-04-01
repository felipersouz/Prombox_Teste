using Prombox.Domain.Commands;
using Prombox.Domain.Commands.Results;
using Prombox.Domain.Entities;
using Prombox.Domain.Repositories;
using Prombox.Domain.Services;
using Prombox.Infra.Transaction;
using System;
using System.Collections.Generic;

namespace Prombox.Service.Services
{
    public class GanhadoresService : BaseService, IGanhadoresService
    {
        private readonly IGanhadoresRepository _repository;
        private readonly INumeroDaSorteRepository _numeroDaSorteRepository;

        public GanhadoresService(IUnitOfWork uow, IGanhadoresRepository repository,
            INumeroDaSorteRepository numeroDaSorteRepository) : base(uow)
        {
            _repository = repository;
            _numeroDaSorteRepository = numeroDaSorteRepository;
        }

        public GanhadoresCreateCommandResult Create(GanhadoresCreateCommand command)
        {
            Ganhador model = null;
            var erros = new List<string>();
            var numeroDaSorte = _numeroDaSorteRepository.GetBy(command.Numero, command.CampanhaId);

            if (numeroDaSorte == null)
                erros.Add("Número da sorte não encontrado");


            var ganhador = _repository.GetByNumeroDaSorte(command.CampanhaId, command.Numero);
            if (ganhador != null)
                erros.Add("Ganhador já cadastrado");

            if (erros.Count == 0)
            {
                model = new Ganhador
                {
                    CampanhaId = command.CampanhaId,
                    NumeroDaSorteId = numeroDaSorte.Id,
                    Colocacao = command.Colocacao
                };

                _repository.Create(model);
                Commit();
            }

            return new GanhadoresCreateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        public GanhadoresDeleteCommandResult Delete(GanhadoresDeleteCommand command)
        {
            var erros = new List<string>();

            try
            {
                var model = _repository.GetById(command.Id);

                if (erros.Count == 0)
                {
                    _repository.Delete(model);

                    Commit();
                }
            }
            catch (Exception ex)
            {
                erros.Add(ex.Message);
                erros.Add(ex.StackTrace);
            }

            return new GanhadoresDeleteCommandResult
            {
                Errors = erros
            };
        }



        public List<Ganhador> GetAll(int camapanhaId)
        {
            return _repository.GetAll(camapanhaId);
        }

        public Ganhador GetById(int id)
        {
            return _repository.GetById(id);
        }

    }
}
