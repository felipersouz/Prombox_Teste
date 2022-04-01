using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Repositories
{
    public interface IUsuariosClientesRepository
    {
        void Create(UsuarioCliente model);
        void Update(UsuarioCliente model);
        bool IsCodigoRecuperacaoUtilizado(int codigo);
        void Delete(UsuarioCliente model);
        UsuarioCliente GetById(long id);
        List<UsuarioCliente> GetAll();
        List<UsuarioCliente> GetAll(int start, int limit, out int total);
        UsuarioCliente GetByClienteId(long clienteId);
        bool CheckCpfCadastrado(string cpf, int empresaId);
        bool CpfDuplicado(string cpf, int empresaId, long clienteId);
        UsuarioCliente GetByCpf(string cpf);

    }
}
