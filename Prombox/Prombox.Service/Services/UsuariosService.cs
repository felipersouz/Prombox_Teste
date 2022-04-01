using Microsoft.EntityFrameworkCore;
using Prombox.Domain.Commands;
using Prombox.Domain.Commands.Results;
using Prombox.Domain.Entities;
using Prombox.Domain.Repositories;
using Prombox.Domain.Scopes;
using Prombox.Domain.Services;
using Prombox.Infra.Transaction;
using PromboxUtil.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Service.Services
{
    public class UsuariosService : BaseService, IUsuariosService
    {
        private readonly IUsuarioRepository _repository;
        private readonly ICurrentUser _currentUser;
        private readonly IMailService _mailService;
        public event EventHandler<UsuariosCreateEventArgs> CreateEventHandler;
        public event EventHandler<UsuariosUpdateEventArgs> UpdateEventHandler;
        public event EventHandler<UsuariosDeleteEventArgs> DeleteEventHandler;

        public UsuariosService(IUnitOfWork uow, IUsuarioRepository repository, ICurrentUser currentUser, IMailService mailService) : base(uow)
        {
            _repository = repository;
            _currentUser = currentUser;
            _mailService = mailService;
        }

        protected virtual void OnCreateEventEvent(UsuariosCreateEventArgs e)
        {
            CreateEventHandler?.Invoke(this, e);
        }

        protected virtual void OnUpdateEvent(UsuariosUpdateEventArgs e)
        {
            UpdateEventHandler?.Invoke(this, e);
        }

        protected virtual void OnDeleteEvent(UsuariosDeleteEventArgs e)
        {
            DeleteEventHandler?.Invoke(this, e);
        }

        public UsuarioCreateCommandResult Create(UsuarioCreateCommand command)
        {
            var model = command.ToModel();

            var erros = model.CreateValidate();

            if (erros.Count == 0)
            {
                var existeEmail = _repository.ExistsEmail(model.Id, model.Email);
                if (existeEmail) erros.Add(string.Format("O e-mail {0} já foi cadastrado.", model.Email));

                if (!existeEmail)
                {
                    _repository.Create(model);
                    Commit();

                    _mailService.NovoUsuario(model.Nome, model.Email, command.Senha);

                    OnCreateEventEvent(new UsuariosCreateEventArgs { });
                }
            }

            return new UsuarioCreateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        public UsuarioDeleteCommandResult Delete(UsuarioDeleteCommand command)
        {
            var erros = new List<string>();

            try
            {
                var model = _repository.GetById(command.Id);

                if (erros.Count == 0)
                {
                    _repository.Delete(model);
                    Commit();

                    OnDeleteEvent(new UsuariosDeleteEventArgs { });
                }
            }
            catch (DbUpdateException ex)
            {
                erros.Add("O usuário não pode ser excluído.");
            }
            catch (Exception ex)
            {
                erros.Add(ex.Message);
            }

            return new UsuarioDeleteCommandResult
            {
                Errors = erros
            };
        }

        public UsuarioUpdateCommandResult Update(UsuarioUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model = command.ToModel(model);

            var erros = model.UpdateValidate();

            if (erros.Count == 0)
            {
                var existeEmail = _repository.ExistsEmail(model.Id, model.Email);
                if (existeEmail) erros.Add(string.Format("O e-mail {0} já foi cadastrado.", model.Email));
                if (!existeEmail)
                {
                    _repository.Update(model);
                    Commit();

                    OnUpdateEvent(new UsuariosUpdateEventArgs { });
                }
            }

            return new UsuarioUpdateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        private UsuarioUpdateCommandResult Update(Usuario model)
        {
            var erros = model.UpdateValidate();

            if (erros.Count == 0)
            {
                _repository.Update(model);
                Commit();
            }

            return new UsuarioUpdateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        public Usuario GetById(long id)
        {
            return _repository.GetById(id);
        }

        public List<Usuario> GetAll(string nome, int start, int limit, out int total)
        {
            return _repository.GetAll(nome, start, limit, out total);
        }

        public List<string> AlterarSenha(AlterarSenhaCommand command)
        {
            var erros = new List<string>();

            if (String.IsNullOrEmpty(command.SenhaAtual))
                erros.Add("Senha atual não informada.");

            if (String.IsNullOrEmpty(command.NovaSenha))
                erros.Add("Nova senha não informada.");

            if (String.IsNullOrEmpty(command.ConfirmaNovaSenha))
                erros.Add("Confirma nova senha não informada.");

            if (erros.Count > 0)
                return erros;

            if (command.NovaSenha != command.ConfirmaNovaSenha)
            {
                erros.Add("Nova senha e confirma nova senha não são iguais.");
                return erros;
            }

            if (command.NovaSenha.Length > 255)
            {
                erros.Add("Senha inválida");
                return erros;
            }

            var usuario = _repository.GetById(_currentUser.Id);

            if (usuario == null)
                erros.Add("Usuário não encontrado.");

            var senhAtual = Criptografia.CalcularMD5Hash(command.SenhaAtual);

            if (senhAtual != usuario.Senha)
            {
                erros.Add("Senha atual inválida.");
                return erros;
            }

            usuario.Senha = Criptografia.CalcularMD5Hash(command.NovaSenha);

            _repository.Update(usuario);
            Commit();

            return erros;
        }

        public List<string> EsqueciSenha(EsqueciSenhaCommand command)
        {
            var errors = new List<string>();
            var usuario = _repository.GetByEmail(command.Email);

            if (usuario == null)
                errors.Add("E-mail não encontrado.");

            if (errors.Count == 0)
            {
                var code = new Random().Next(1000, 9999);
                var encrypted = WebUtility.UrlEncode(Criptografia.EasyEncrypt(usuario.Id + "|" + code.ToString()));

                _mailService.RecuperarSenha(usuario.Nome, usuario.Email, code, encrypted);
            }

            return errors;
        }

        public List<string> RecuperarSenha(RecuperarSenhaCommand command)
        {
            var errors = new List<string>();

            if (command.Code < 1000 || command.Code > 9999)
                errors.Add("Código inválido.");

            if (String.IsNullOrEmpty(command.CodeEncrypt))
                errors.Add("Código Url inválido.");

            if (errors.Count == 0)
            {
                try
                {
                    var decrypted = Criptografia.EasyDecrypt(command.CodeEncrypt);
                    var arr = decrypted.Split('|');

                    if (arr[1] != command.Code.ToString())
                        errors.Add("Código inválido.");
                    else
                    {
                        var id = Convert.ToInt32(arr[0]);
                        var usuario = _repository.GetById(id);
                        var novaSenha = Criptografia.GeradorDeSenha(8);
                        var novaSenhaEncriptada = Criptografia.CalcularMD5Hash(novaSenha);

                        usuario.Senha = novaSenhaEncriptada;
                        _repository.Update(usuario);
                        Commit();

                        _mailService.NovaSenha(usuario.Nome, usuario.Email, novaSenha);
                    }
                }
                catch (Exception)
                {
                    errors.Add("Código Url inválido.");
                }
            }

            return errors;
        }
    }
}
