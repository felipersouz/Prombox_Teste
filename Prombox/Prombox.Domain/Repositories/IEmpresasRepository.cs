using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Repositories
{
    public interface IEmpresasRepository
    {
        void Create(Empresa model);
        void Update(Empresa model);
        void Delete(Empresa model);
        Empresa GetById(int id);
        List<Empresa> GetAll();
        List<Empresa> GetAll(string nome, int start, int limit, out int total);
        bool ExixtsCnpf(int id, string cnpj);
    }
}
