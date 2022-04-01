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
    public class UsuarioClienteRepository : BaseRepository, IUsuariosClientesRepository
    {
        public UsuarioClienteRepository(DataContext context) : base(context)
        {

        }

        public bool IsCodigoRecuperacaoUtilizado(int codigo)
        {
            return _context.UsuariosClientes.Where(x => x.CodigoRecuperacaoSenha == codigo.ToString()).Any();
        }
        public UsuarioCliente GetByCpf(string cpf)
        {            
            return _context.UsuariosClientes
                .Include(x=> x.Cliente)
                .Where(x=> x.Cliente.Cpf == cpf).FirstOrDefault();
        }

        public void Create(UsuarioCliente model)
        {
            _context.UsuariosClientes.Add(model);
        }

        public void Update(UsuarioCliente model)
        {
            _context.Entry<UsuarioCliente>(model).State = EntityState.Detached;
            _context.Entry<UsuarioCliente>(model).State = EntityState.Modified;
        }

        public void Delete(UsuarioCliente model)
        {
            _context.Entry<UsuarioCliente>(model).State = EntityState.Deleted;
        }

        public UsuarioCliente GetById(long id)
        {
            return _context.UsuariosClientes.Where(UsuariosClientesSpacs.GetById(id))
                .Include(x=> x.Cliente)
                .SingleOrDefault();
        }

        public bool CheckCpfCadastrado(string cpf, int empresaId)
        {
            return _context.Clientes.Where(x => x.Cpf == cpf && x.EmpresaId == empresaId).Any();
        }


        public bool CpfDuplicado(string cpf, int empresaId, long clienteId)
        {
            return _context.Clientes.Where(x => x.Cpf == cpf && x.EmpresaId == empresaId && x.Id != clienteId).Any();
        }

        public UsuarioCliente GetByClienteId(long clienteId)
        {
            return _context.UsuariosClientes.Where(UsuariosClientesSpacs.GetByClienteId(clienteId)).SingleOrDefault();
        }

        public List<UsuarioCliente> GetAll()
        {
            return _context.UsuariosClientes.ToList();
        }

        public List<UsuarioCliente> GetAll(int start, int limit, out int total)
        {
            total = _context.UsuariosClientes.Count();

            return _context.UsuariosClientes
                .OrderBy(x => x.Id)
                .Skip(start * limit)
                .Take(limit)
                .ToList();
        }
    }
}
