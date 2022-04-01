using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Prombox.Domain.Entities;
using Prombox.Domain.Repositories;
using Prombox.Domain.Spacs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Prombox.Infra.Repositories
{
    public class NumeroDaSorteRepository : BaseRepository, INumeroDaSorteRepository
    {
        IConfiguration _configuration;
        public NumeroDaSorteRepository(DataContext context, IConfiguration configuration) : base(context)
        {
            _configuration = configuration;
        }

        public NumeroDaSorte GetById(long id)
        {
            return _context.NumerosDaSorte.Where(NumeroDaSorteSpacs.GetById(id)).SingleOrDefault();
        }

        public void Update(NumeroDaSorte model)
        {
            _context.Entry<NumeroDaSorte>(model).State = EntityState.Detached;
            _context.Entry<NumeroDaSorte>(model).State = EntityState.Modified;
        }

        public void UpdateDetalhe(NumeroDaSorteDetalhe model)
        {
            _context.Entry<NumeroDaSorteDetalhe>(model).State = EntityState.Detached;
            _context.Entry<NumeroDaSorteDetalhe>(model).State = EntityState.Modified;
        }

        public void CreateDetalhe(NumeroDaSorteDetalhe model)
        {
            _context.Entry<NumeroDaSorteDetalhe>(model).State = EntityState.Added;
        }

        public NumeroDaSorte GetBy(long numero, int campanhaId)
        {
            return _context.NumerosDaSorte.Where(NumeroDaSorteSpacs.GetBy(numero, campanhaId)).SingleOrDefault();
        }

        public long EscolherNumeroDaSorte(long clienteId, int campanhaId)
        {
            long retorno = 0;
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                using (var command = new SqlCommand("dbo.EscolherNumeroDaSorte", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ClienteId", clienteId));
                    command.Parameters.Add(new SqlParameter("@CampanhaId", campanhaId));

                    connection.Open();
                    retorno = (long)command.ExecuteScalar();
                    connection.Close();
                }

                return retorno;
            }
        }

        public List<NumeroDaSorte> GetMines(long clienteId, int campanhaId)
        {
            return _context.NumerosDaSorte.Where(NumeroDaSorteSpacs.GetMines(clienteId, campanhaId)).OrderBy(x => x.DataHoraAssociacao).ToList();            
        }
    }
}
