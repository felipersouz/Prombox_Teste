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
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace Prombox.Infra.Repositories
{
    public class NotaFiscalRepository : BaseRepository, INotasFiscaisRepository
    {
        IConfiguration _configuration;
        public NotaFiscalRepository(DataContext context, IConfiguration configuration) : base(context)
        {
            _configuration = configuration;
        }

        public void Create(NotaFiscal model)
        {
            _context.NotasFiscais.Add(model);
        }

        public void Update(NotaFiscal model)
        {
            _context.Entry<NotaFiscal>(model).State = EntityState.Detached;
            _context.Entry<NotaFiscal>(model).State = EntityState.Modified;
            
        }

        public void Delete(NotaFiscal model)
        {
            _context.Entry<NotaFiscal>(model).State = EntityState.Deleted;
        }

        public NotaFiscal GetById(long id)
        {
            return _context.NotasFiscais.Where(NotasFiscaisSpacs.GetById(id)).SingleOrDefault();
        }

        public List<NotaFiscal> GetAll()
        {
            return _context.NotasFiscais.ToList();
        }

        public List<NotaFiscal> GetAllWithSaldo(long usuarioClienteId, int campanhaId)
        {
            return _context.NotasFiscais.Where(NotasFiscaisSpacs.GetAllWithSaldo(usuarioClienteId, campanhaId))
                .OrderBy(x=> x.Id)
                .ToList();
        }

        public List<NotaFiscal> GetByUsuarioClienteCampanha(long usuarioClienteId, int campanhaId)
        {
            return _context.NotasFiscais.Where(NotasFiscaisSpacs.GetByUsuarioClienteCampanha(usuarioClienteId, campanhaId)).ToList();
        }

        public List<NotaFiscal> GetByUsuarioClienteCampanhaCodigoNota(long usuarioClienteId, int campanhaId, string codigoNota)
        {
            return _context.NotasFiscais.Where(NotasFiscaisSpacs.GetByUsuarioClienteCampanhaCodigoNota(usuarioClienteId, campanhaId, codigoNota)).ToList();
        }

        public decimal GetTotalNotasByUsuarioClienteCampanha(long usuarioClienteId, int campanhaId)
        {
            decimal retorno = 0;
            string query = string.Format("select ISNULL(sum(ValorTotal),0) as Total from [dbo].[NotasFiscais] where UsuarioClienteId = {0} and CampanhaId = {1}", usuarioClienteId, campanhaId);
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    retorno = decimal.Parse(cmd.ExecuteScalar().ToString());
                }
                catch (Exception ex)
                {
                    
                }
            }
            return retorno;
        }
                              
        public List<NotaFiscal> GetAll(int start, int limit, out int total)
        {
            total = _context.NotasFiscais.Count();

            return _context.NotasFiscais
                .OrderBy(x => x.Id)
                .Skip(start * limit)
                .Take(limit)
                .ToList();
        }

        public decimal GetSaldo(long usuarioClienteId, int campanhaId)
        {
            decimal retorno = 0;
            string query = string.Format("select ISNULL(sum(Saldo),0) as Total from [dbo].[NotasFiscais] where UsuarioClienteId = {0} and CampanhaId = {1} GROUP BY UsuarioClienteId, CampanhaId", usuarioClienteId, campanhaId);
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    retorno = decimal.Parse(cmd.ExecuteScalar().ToString());
                }
                catch (Exception ex)
                {
                    
                }
            }
            return retorno;
        }
    }
}
