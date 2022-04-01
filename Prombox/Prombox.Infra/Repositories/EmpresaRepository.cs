using Prombox.Domain.Entities;
using Prombox.Domain.Spacs;
using Prombox.Domain.Repositories;
using Prombox.Infra;
using Prombox.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Prombox.Infra.Repositories
{
    public class EmpresaRepository : BaseRepository, IEmpresasRepository
    {
        public EmpresaRepository(DataContext context) : base(context)
        {

        }

        public void Create(Empresa model)
        {
            _context.Empresas.Add(model);
        }

        public void Update(Empresa model)
        {
            _context.Entry<Empresa>(model).State = EntityState.Detached;
            _context.Entry<Empresa>(model).State = EntityState.Modified;
        }

        public void Delete(Empresa model)
        {
            _context.Entry<Empresa>(model).State = EntityState.Deleted;
        }

        public Empresa GetById(int id)
        {
            return _context.Empresas.Where(EmpresasSpacs.GetById(id)).SingleOrDefault();
        }

        public List<Empresa> GetAll()
        {
            return _context.Empresas.ToList();
        }

        public List<Empresa> GetAll(string nome, int start, int limit, out int total)
        {
            total = _context.Empresas.Where(EmpresasSpacs.GetByName(nome)).Count();

            return _context.Empresas
                .Where(EmpresasSpacs.GetByName(nome))
                .OrderBy(x => x.NomeFantasia)
                .Skip(start * limit)
                .Take(limit)
                .ToList();
        }

        public bool ExixtsCnpf(int id, string cnpj)
        {
            return _context.Empresas.Any(EmpresasSpacs.ExixtsCnpf(id, cnpj));
        }
    }
}
