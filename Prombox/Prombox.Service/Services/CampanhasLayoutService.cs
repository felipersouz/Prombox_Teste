using Prombox.Domain.Commands;
using Prombox.Domain.Commands.Results;
using Prombox.Domain.Entities;
using Prombox.Domain.Repositories;
using Prombox.Domain.Scopes;
using Prombox.Domain.Services;
using Prombox.Infra.Transaction;
using Prombox.Service.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Prombox.Service.Services
{
    public class CampanhasLayoutService : BaseService, ICampanhasLayoutService
    {
        private readonly ICampanhasLayoutRepository _repository;
        public event EventHandler<CampanhasLayoutCreateEventArgs> CreateEventHandler;
        public event EventHandler<CampanhasLayoutUpdateEventArgs> UpdateEventHandler;
        public event EventHandler<CampanhasLayoutDeleteEventArgs> DeleteEventHandler;

        public CampanhasLayoutService(IUnitOfWork uow, ICampanhasLayoutRepository repository) : base(uow)
        {
            _repository = repository;
        }

        protected virtual void OnCreateEventEvent(CampanhasLayoutCreateEventArgs e)
        {
            CreateEventHandler?.Invoke(this, e);
        }

        protected virtual void OnUpdateEvent(CampanhasLayoutUpdateEventArgs e)
        {
            UpdateEventHandler?.Invoke(this, e);
        }

        protected virtual void OnDeleteEvent(CampanhasLayoutDeleteEventArgs e)
        {
            DeleteEventHandler?.Invoke(this, e);
        }

        public CampanhaLayoutCreateCommandResult Create(CampanhaLayoutCreateCommand command)
        {
            var model = command.ToModel();

            var erros = model.CreateValidate();

            if (erros.Count == 0)
            {
                _repository.Create(model);
                Commit();

                OnCreateEventEvent(new CampanhasLayoutCreateEventArgs { });
            }

            return new CampanhaLayoutCreateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        public CampanhaLayoutDeleteCommandResult Delete(CampanhaLayoutDeleteCommand command)
        {
            var erros = new List<string>();

            try
            {
                var model = _repository.GetById(command.Id);

                if (erros.Count == 0)
                {
                    _repository.Delete(model);

                    Commit();

                    OnDeleteEvent(new CampanhasLayoutDeleteEventArgs { });
                }
            }
            catch (Exception ex)
            {
                erros.Add(ex.Message);
                erros.Add(ex.StackTrace);
            }

            return new CampanhaLayoutDeleteCommandResult
            {
                Errors = erros
            };
        }

        public CampanhaLayoutUpdateCommandResult Update(CampanhaLayoutUpdateCommand command)
        {
            var path = DiretorioService.GetCaminhoCampanha(command.CampanhaId);
            var model = _repository.GetById(command.Id);

            var urlLogo = !string.IsNullOrEmpty(model.UrlLogo) ? Path.Combine(path, Path.GetFileName(model.UrlLogo)) : "";
            var urlCampanha = !string.IsNullOrEmpty(model.UrlCampanha) ? Path.Combine(path, Path.GetFileName(model.UrlCampanha)) : "";
            var urlRegulamento = !string.IsNullOrEmpty(model.UrlRegulamento) ? Path.Combine(path, Path.GetFileName(model.UrlRegulamento)) : "";
            var urlComoParticipar = !string.IsNullOrEmpty(model.UrlComoParticipar) ? Path.Combine(path, Path.GetFileName(model.UrlComoParticipar)) : "";
            var urlBanner1 = !string.IsNullOrEmpty(model.UrlBanner1) ? Path.Combine(path, Path.GetFileName(model.UrlBanner1)) : "";
            var urlBanner2 = !string.IsNullOrEmpty(model.UrlBanner2) ? Path.Combine(path, Path.GetFileName(model.UrlBanner2)) : "";
            var urlBanner3 = !string.IsNullOrEmpty(model.UrlBanner3) ? Path.Combine(path, Path.GetFileName(model.UrlBanner3)) : "";

            model = command.ToModel(model);

            var erros = model.UpdateValidate();

            if (erros.Count == 0)
            {
                _repository.Update(model);
                Commit();

                if (command.ExcluirUrlLogo && File.Exists(urlLogo)) File.Delete(urlLogo);
                if (command.ExcluirUrlCampanha && File.Exists(urlCampanha)) File.Delete(urlCampanha);
                if (command.ExcluirUrlRegulamento && File.Exists(urlRegulamento)) File.Delete(urlRegulamento);
                if (command.ExcluirUrlComoParticipar && File.Exists(urlComoParticipar)) File.Delete(urlComoParticipar);
                if (command.ExcluirUrlBanner1 && File.Exists(urlBanner1)) File.Delete(urlBanner1);
                if (command.ExcluirUrlBanner2 && File.Exists(urlBanner2)) File.Delete(urlBanner2);
                if (command.ExcluirUrlBanner3 && File.Exists(urlBanner3)) File.Delete(urlBanner3);

                OnUpdateEvent(new CampanhasLayoutUpdateEventArgs { });
            }

            return new CampanhaLayoutUpdateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        public CampanhaLayoutUpdateCommandResult UpdateCampanhaId(CampanhaLayoutUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.CampanhaId = command.CampanhaId;

            return Update(model);
        }
        public CampanhaLayoutUpdateCommandResult UpdateUrlLogo(CampanhaLayoutUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.UrlLogo = command.UrlLogo;

            return Update(model);
        }
        public CampanhaLayoutUpdateCommandResult UpdateUrlCampanha(CampanhaLayoutUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.UrlCampanha = command.UrlCampanha;

            return Update(model);
        }
        public CampanhaLayoutUpdateCommandResult UpdateUrlRegulamento(CampanhaLayoutUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.UrlRegulamento = command.UrlRegulamento;

            return Update(model);
        }
        public CampanhaLayoutUpdateCommandResult UpdateUrlInstagram(CampanhaLayoutUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.UrlInstagram = command.UrlInstagram;

            return Update(model);
        }
        public CampanhaLayoutUpdateCommandResult UpdateUrlComoParticipar(CampanhaLayoutUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.UrlComoParticipar = command.UrlComoParticipar;

            return Update(model);
        }
        public CampanhaLayoutUpdateCommandResult UpdateUrlFacebook(CampanhaLayoutUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.UrlFacebook = command.UrlFacebook;

            return Update(model);
        }
        public CampanhaLayoutUpdateCommandResult UpdateUrlBanner1(CampanhaLayoutUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.UrlBanner1 = command.UrlBanner1;

            return Update(model);
        }
        public CampanhaLayoutUpdateCommandResult UpdateUrlBanner2(CampanhaLayoutUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.UrlBanner2 = command.UrlBanner2;

            return Update(model);
        }
        public CampanhaLayoutUpdateCommandResult UpdateUrlBanner3(CampanhaLayoutUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.UrlBanner3 = command.UrlBanner3;

            return Update(model);
        }
        public CampanhaLayoutUpdateCommandResult UpdateCorFundoSite(CampanhaLayoutUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.CorFundoSite = command.CorFundoSite;

            return Update(model);
        }
        public CampanhaLayoutUpdateCommandResult UpdateCorBotoes(CampanhaLayoutUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.CorBotoes = command.CorBotoes;

            return Update(model);
        }
        public CampanhaLayoutUpdateCommandResult UpdateCorCabecalhoRodape(CampanhaLayoutUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.CorCabecalhoRodape = command.CorCabecalhoRodape;

            return Update(model);
        }


        private CampanhaLayoutUpdateCommandResult Update(CampanhaLayout model)
        {
            var erros = model.UpdateValidate();

            if (erros.Count == 0)
            {
                _repository.Update(model);
                Commit();
            }

            return new CampanhaLayoutUpdateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        public List<CampanhaLayout> GetAll()
        {
            return _repository.GetAll();
        }

        public CampanhaLayout GetById(int id)
        {
            return _repository.GetById(id);
        }

        public CampanhaLayout GetByCampanhaId(int campanhaId)
        {
            return _repository.GetByCampanhaId(campanhaId);
        }

        public List<CampanhaLayout> GetAll(int start, int limit, out int total)
        {
            return _repository.GetAll(start, limit, out total);
        }
    }
}
