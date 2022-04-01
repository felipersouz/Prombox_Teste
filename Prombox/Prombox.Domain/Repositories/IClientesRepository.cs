using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Repositories
{
    public interface IClientesRepository
    {
        void Create(Cliente model);
        void Update(Cliente model);
        void Delete(Cliente model);
        Cliente GetById(long id);
        List<Cliente> GetAll();
        List<Cliente> GetAll(int start, int limit, out int total);
        Cliente GetByCpf(string cpf, int empresaId);
        Cliente GetByCpfOrEmail(string cpf, string email); 
        Cliente GetByEmail(string email);

    }
}
