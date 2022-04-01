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
    public class ClienteRepository : BaseRepository, IClientesRepository
    {
        public ClienteRepository(DataContext context) : base(context)
        {

        }

        public void Create(Cliente model)
        {
            _context.Clientes.Add(model);
            //return model;
        }

        public void Update(Cliente model)
        {
            _context.Entry<Cliente>(model).State = EntityState.Detached;
            _context.Entry<Cliente>(model).State = EntityState.Modified;
        }

        public void Delete(Cliente model)
        {
            _context.Entry<Cliente>(model).State = EntityState.Deleted;
        }

        public Cliente GetById(long id)
        {
            return _context.Clientes.Where(ClientesSpacs.GetById(id)).SingleOrDefault();
        }

        public Cliente GetByCpf(string cpf, int empresaId)
        {
            return _context.Clientes.Where(ClientesSpacs.GetByCpfEmpresa(cpf, empresaId)).FirstOrDefault();
        }
        public Cliente GetByCpfOrEmail(string cpf, string email)
        {
            return _context.Clientes.Where(ClientesSpacs.GetByCpfOrEmail(cpf, email)).FirstOrDefault();
        }


        public Cliente GetByEmail(string email)
        {
            return _context.Clientes.Where(ClientesSpacs.GetByEmail(email)).FirstOrDefault();
        }

        public List<Cliente> GetAll()
        {
            return _context.Clientes.ToList();
        }

        public List<Cliente> GetAll(int start, int limit, out int total)
        {
            total = _context.Clientes.Count();

            return _context.Clientes
                .OrderBy(x => x.Id)
                .Skip(start * limit)
                .Take(limit)
                .ToList();
        }

    }
}
