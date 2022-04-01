using Prombox.Domain.Commands;
using Prombox.Domain.Commands.Results;
using Prombox.Domain.Entities;
using Prombox.Domain.Repositories;
using Prombox.Domain.Scopes;
using Prombox.Domain.Services;
using Prombox.Infra.Transaction;
using Prombox.Service.Utilities;
using PromboxUtil.Cryptography;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Prombox.Service.Services
{
    public class UsuarioClienteService : BaseService, IUsuariosClientesService
    {
        private readonly IUsuariosClientesRepository _repository;
        private readonly IClientesRepository _clienteRepository;
        private readonly IMailService _mailService;
        public event EventHandler<UsuariosClientesCreateEventArgs> CreateEventHandler;
        public event EventHandler<UsuariosClientesUpdateEventArgs> UpdateEventHandler;
        public event EventHandler<UsuariosClientesDeleteEventArgs> DeleteEventHandler;

        public UsuarioClienteService(IUnitOfWork uow, IUsuariosClientesRepository repository, 
            IClientesRepository clienteRepository,
            IMailService mailService
            ) : base(uow)
        {
            _repository = repository;
            _clienteRepository = clienteRepository;
            _mailService = mailService;
        }

        protected virtual void OnCreateEventEvent(UsuariosClientesCreateEventArgs e)
        {
            CreateEventHandler?.Invoke(this, e);
        }

        protected virtual void OnUpdateEvent(UsuariosClientesUpdateEventArgs e)
        {
            UpdateEventHandler?.Invoke(this, e);
        }

        protected virtual void OnDeleteEvent(UsuariosClientesDeleteEventArgs e)
        {
            DeleteEventHandler?.Invoke(this, e);
        }


        //public void TestaEmail()
        //{
        //    // _mailService.NovoUsuarioCliente("Novo Usuário Hugo", "atendimento@prombox.com.br");
        //    _mailService.NovoUsuarioCliente("QA Master", "luiz@evot.com.br");
        //}

        public UsuarioClienteCreateCommandResult Create(UsuarioClienteCreateCommand command)
        {
            try
            {
                List<string> erros = new List<string>();

                string cpfComMascara = command.Cpf;
                // limpo o cpf e o email
                var matchCollection = Regex.Matches(command.Cpf, @"\d+");
                var novoCpf = "";
                foreach (Match m in matchCollection)
                {
                    novoCpf += m.Value;
                }
                command.Cpf = novoCpf;
                command.Email = command.Email.Trim();

                var usuarioExistente = _clienteRepository.GetByCpf(command.Cpf, command.EmpresaId);

                if (usuarioExistente!=null)
                    erros.Add("Já temos um cadastro com esse CPF no nosso banco de dados. Tente recuperar sua senha.");


                var usuarioCliente = command.ToUsuarioCliente();
                usuarioCliente = CreatePasswordHashAndSalt(command.Senha, usuarioCliente);

                var cliente = command.ToCliente();

                string[] dt = command.DataNascimento.Split("/");

                var diaNascimento = new DateTime(int.Parse(dt[2]), int.Parse(dt[1]), int.Parse(dt[0]));
                cliente.DataNascimento = diaNascimento;

                var erros1 = usuarioCliente.CreateValidate();
                var erros2 = cliente.CreateValidate();


                erros.AddRange(erros1);
                erros.AddRange(erros2);


                if (erros.Count == 0)
                {
                    _clienteRepository.Create(cliente);
                    Commit();

                    usuarioCliente.ClienteId = cliente.Id;

                    _repository.Create(usuarioCliente);
                    Commit();


                    _mailService.NovoUsuarioCliente(cliente.Nome, cliente.Email, cpfComMascara);
                    // Enviar email de boas vindas aqui
                    OnCreateEventEvent(new UsuariosClientesCreateEventArgs { });
                }

                return new UsuarioClienteCreateCommandResult
                {
                    Errors = erros,
                    Model = usuarioCliente,
                    UrlRedirect = "/cliente/notas/cadastrar"
                };

            }catch (Exception ex)
            {
                List<string> erros = new List<string>();
                erros.Add(ex.ToString());

                return new UsuarioClienteCreateCommandResult
                {                    
                    Errors = erros,
                    Model = null,
                    UrlRedirect = "/cliente/notas/cadastrar"
                };
            }
        }

        public bool CheckCpfCadastrado(string cpf, int empresaId)
        {
            // limpo o cpf
            var matchCollection = Regex.Matches(cpf, @"\d+");
            var novoCpf = "";
            foreach (Match m in matchCollection)
            {
                novoCpf += m.Value;
            }
            cpf = novoCpf;

            var result = _repository.CheckCpfCadastrado(cpf, empresaId);

            return result;
        }

        public CommandResult AlterarSenha(AlterarSenhaCommand command, long usuarioClienteId)
        {
            try
            {
                List<string> erros = new List<string>();
                var model = _repository.GetById(usuarioClienteId);
                                               
                var hashAtual = Crypt.HashWithSalt(command.SenhaAtual, model.Salt);

                if (model.PasswordHash != hashAtual)
                    erros.Add("A senha atual não confere.");
                
                var novoHash = Crypt.HashWithSalt(command.NovaSenha, model.Salt);

                if (model.PasswordHash.Equals(novoHash))
                {
                    erros.Add("Não é permitido atualizar a senha para a mesma que a atual.");
                }

                if (erros.Count == 0)
                {                    
                    model.Salt = Crypt.CreateSalt();
                    model.PasswordHash = Crypt.HashWithSalt(command.NovaSenha, model.Salt);

                    _repository.Update(model);
                    Commit();
                    string cpfComMascara = model.Cliente.Cpf.Substring(0, 3) + "." + model.Cliente.Cpf.Substring(3, 3) + "." + model.Cliente.Cpf.Substring(6, 3) + "-" + model.Cliente.Cpf.Substring(9, 2);
                    _mailService.SenhaAlterada(model.Cliente.Nome, model.Cliente.Email, cpfComMascara); 

                }

                return new CommandResult
                {
                    Errors = erros
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UsuarioClienteUpdateCommandResult Update(UsuarioClienteUpdateCommand command)
        {
            try
            {
                List<string> erros = new List<string>();
                var model = _repository.GetById(command.Id);

                model = command.ToUpdate(model, command);

                // limpo o cpf e o email
                var matchCollection = Regex.Matches(command.Cpf, @"\d+");
                var novoCpf = "";
                foreach (Match m in matchCollection)
                {
                    novoCpf += m.Value;
                }
                model.Cliente.Cpf = novoCpf;
                command.Cpf = novoCpf;
                model.Email = command.Email.Trim();
                model.Cliente.Email = command.Email.Trim();

                string[] dt = command.DataNascimento.Split("/");

                var diaNascimento = new DateTime(int.Parse(dt[2]), int.Parse(dt[1]), int.Parse(dt[0]));
                model.Cliente.DataNascimento = diaNascimento;


                if (_repository.CpfDuplicado(command.Cpf, command.EmpresaId, command.Id))
                {
                    erros.Add("Esse CPF já se encontra cadastrado em outra conta. Entre em contato com o SAC");
                }

                if (erros.Count == 0)
                {
                    _repository.Update(model);
                    Commit();

                    OnUpdateEvent(new UsuariosClientesUpdateEventArgs { });
                }

                return new UsuarioClienteUpdateCommandResult
                {
                    Errors = erros,
                    Model = model
                };
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public UsuarioCliente CreatePasswordHashAndSalt (string password, UsuarioCliente u)
        {
            u.Salt = Crypt.CreateSalt();
            u.PasswordHash = Crypt.HashWithSalt(password, u.Salt);
            u.Pepper = Crypt.GetPepper();
            return u;
        }

        public bool ValidatePassword(string password, UsuarioCliente u)
        {            
            var newPasswordHash = Crypt.HashWithSalt(password, u.Salt);
            return u.PasswordHash == newPasswordHash;
        }
        public UsuarioClienteDeleteCommandResult Delete(UsuarioClienteDeleteCommand command)
        {
            var erros = new List<string>();

            try
            {
                var model = _repository.GetById(command.Id);

                if (erros.Count == 0)
                {
                    _repository.Delete(model);

                    Commit();

                    OnDeleteEvent(new UsuariosClientesDeleteEventArgs { });
                }
            }
            catch (Exception ex)
            {
                erros.Add(ex.Message);
                erros.Add(ex.StackTrace);
            }

            return new UsuarioClienteDeleteCommandResult
            {
                Errors = erros
            };
        }
        public UsuarioClienteUpdateCommandResult UpdateIsExcluido(UsuarioClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            //model.IsExcluido = command.IsExcluido;

            return Update(model);
        }
        public UsuarioClienteUpdateCommandResult UpdateUsuarioExclusao(UsuarioClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            //model.UsuarioExclusao = command.UsuarioExclusao;

            return Update(model);
        }
        public UsuarioClienteUpdateCommandResult UpdateDataHoraExclusao(UsuarioClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            //model.DataHoraExclusao = command.DataHoraExclusao;

            return Update(model);
        }
        public UsuarioClienteUpdateCommandResult UpdateEmail(UsuarioClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Email = command.Email;

            return Update(model);
        }
        public UsuarioClienteUpdateCommandResult UpdateHash(UsuarioClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            //model.Hash = command.Hash;

            return Update(model);
        }
        public UsuarioClienteUpdateCommandResult UpdatePepper(UsuarioClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            //model.Pepper = command.Pepper;

            return Update(model);
        }
        public UsuarioClienteUpdateCommandResult UpdateAtivo(UsuarioClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Ativo = command.Ativo;

            return Update(model);
        }
        public UsuarioClienteUpdateCommandResult UpdateBloqueadoAte(UsuarioClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            //model.BloqueadoAte = command.BloqueadoAte;

            return Update(model);
        }
        private UsuarioClienteUpdateCommandResult Update(UsuarioCliente model)
        {
            var erros = model.UpdateValidate();

            if (erros.Count == 0)
            {
                _repository.Update(model);
                Commit();
            }

            return new UsuarioClienteUpdateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }
        public List<UsuarioCliente> GetAll()
        {
            return _repository.GetAll();
        }

        public UsuarioCliente GetById(long id)
        {            
            return _repository.GetById(id);
        }

        public List<UsuarioCliente> GetAll(int start, int limit, out int total)
        {
            return _repository.GetAll(start, limit, out total);
        }

        public List<string> EsqueceuSenha(EsqueciSenhaCommand2 command, out UsuarioCliente usuarioCliente)
        {
            /* 1 - Captura o usuário a partir do email e campanha
             * 2 - Gera um número aleatório como código de recuperação que não esteja sendo utilizado na tabela
             * 3 - Atualiza o BD com o novo código e data/hora de expiração desse código
             * 4 - Envia o código por email com o link para a página de recuperação
             */

            // limpo o cpf
            var matchCollection = Regex.Matches(command.Cpf, @"\d+");
            var novoCpf = "";
            foreach (Match m in matchCollection)
            {
                novoCpf += m.Value;
            }
            command.Cpf = novoCpf;

            List<string> errors = new List<string>();


            // 1
            usuarioCliente = _repository.GetByCpf(command.Cpf);

            if (usuarioCliente == null)
            {
                errors.Add("Cliente não localizado.");
                return errors;
            }

            // todo: capturar a associaçao de cliente e campanha
            if (usuarioCliente.Cliente.ClientesCampanhas == null)
            {
                // erros.Add("Cliente cadastrado porém não associado à esta campanha. Deseja associar?");
            }

            // 2
            var code = new Random().Next(100000, 999999);
            while(_repository.IsCodigoRecuperacaoUtilizado(code))
                code++;

            // 3
            usuarioCliente.CodigoRecuperacaoSenha = code.ToString();
            usuarioCliente.ExpiracaoCodigoRecuperacaoSenha = DateTime.Now.AddHours(2);
           

            // 4
            if (errors.Count == 0)
            {                
                var encrypted = WebUtility.UrlEncode(Criptografia.EasyEncrypt(usuarioCliente.Id + "|" + code.ToString()));         
                
                _mailService.RecuperarSenhaUsuarioCliente(usuarioCliente.Cliente.Nome, usuarioCliente.Email, usuarioCliente.Cliente.Cpf, code, encrypted);
                _repository.Update(usuarioCliente);
            }

            return errors;
        }

        public List<string> RecuperarSenha(RecuperarSenhaCommand command)
        {
            var errors = new List<string>();

            if (command.Code < 100000 || command.Code > 999999 + 100) // há um pequeno risco do código ficar acima devido a logica do while na geração, por isso a gordura de + 100
                errors.Add("Código inválido.");

            if (String.IsNullOrEmpty(command.CodeEncrypt))
                errors.Add("Código Url inválido.");

            if (errors.Count == 0)
            {
                try
                {

                    command.CodeEncrypt = WebUtility.UrlDecode(command.CodeEncrypt);

                    var decrypted = Criptografia.EasyDecrypt(command.CodeEncrypt);
                    var arr = decrypted.Split('|');

                    if (arr[1] != command.Code.ToString())
                        errors.Add("Código inválido.");
                    else
                    {
                        var id = Convert.ToInt32(arr[0]);
                        var usuario = _repository.GetById(id);
                        var novaSenha = Criptografia.GeradorDeSenha(8);

                        var novoSalt = Crypt.CreateSalt();
                        var novaSenhaEncriptada = Crypt.HashWithSalt(novaSenha, novoSalt);
                        usuario.Salt = novoSalt;
                        usuario.PasswordHash = novaSenhaEncriptada;
                        _repository.Update(usuario);
                        Commit();

                        _mailService.NovaSenha(usuario.Cliente.Nome, usuario.Email, novaSenha);
                    }
                }
                catch (Exception ex)
                {
                    errors.Add("Código Url inválido.");
                }
            }
            return errors;
        }

        public AutenticateClienteCommandResult Autenticate(LoginCommand command)
        {
            var errors = new List<string>();


            // limpo o cpf
            var matchCollection = Regex.Matches(command.Login, @"\d+");
            var novoCpf = "";
            foreach (Match m in matchCollection)
            {
                novoCpf += m.Value;
            }
            command.Login = novoCpf;


            var cliente = _clienteRepository.GetByCpf(command.Login, command.EmpresaId.Value);
            UsuarioCliente usuarioCliente = null;

            if (cliente == null)
                errors.Add("Cpf ou senha inválidos.");
            else
            {
                usuarioCliente = _repository.GetByClienteId(cliente.Id);

                var encrypted = Crypt.HashWithSalt(command.Senha, usuarioCliente.Salt);

                if (usuarioCliente.PasswordHash != encrypted)
                    errors.Add("Cpf ou senha inválidos.");
            }

            if (errors.Count == 0)
            {
                if (!usuarioCliente.Ativo) errors.Add("Usuário desativado. Entre em contato com o SAC.");
            }

            return new AutenticateClienteCommandResult
            {
                Errors = errors,
                Model = usuarioCliente
            };
        }
    }
}
