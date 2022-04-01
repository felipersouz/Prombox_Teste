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
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Prombox.Infra.Repositories
{
    public class AderenteRepository : BaseRepository, IAderenteRepository
    {
        IConfiguration _configuration;

        public AderenteRepository(DataContext context, IConfiguration configuration) : base(context)
        {
            _configuration = configuration;
        }

        public void Create(Aderente model)
        {
            _context.Aderentes.Add(model);
        }

        public void Update(Aderente model)
        {
            _context.Entry<Aderente>(model).State = EntityState.Detached;
            _context.Entry<Aderente>(model).State = EntityState.Modified;
        }

        public void Delete(Aderente model)
        {
            _context.Entry<Aderente>(model).State = EntityState.Deleted;
        }

        public Aderente GetById(int id)
        {
            return _context.Aderentes.Where(AderenteSpacs.GetById(id)).SingleOrDefault();
        }

        public List<Aderente> GetByCampanha(int campanhaId)
        {
            return _context
                .CampanhaAderentes
                .Where(x => x.CampanhaId == campanhaId).Select(x => x.Aderente).ToList();
        }

        public bool IsAssociadoCampanha(string cnpj)
        {
            string query = string.Format(

            @"SELECT 
                A.Id
            FROM 
                CampanhaAderentes CA INNER JOIN Campanhas C
                    ON C.Id = CA.CampanhaId
                INNER JOIN Aderentes A
                    ON A.Id = CA.AderenteId
            WHERE
                A.Cnpj = '{0}'", cnpj);

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    var reader = cmd.ExecuteReader();

                    return reader.HasRows;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<Aderente> GetAll()
        {
            return _context.Aderentes.ToList();
        }

        public List<Aderente> GetAll(int? empresaId, string nome, int start, int limit, out int total)
        {
            total = _context.Aderentes
                .Where(AderenteSpacs.GetBy(empresaId, nome)).Count();

            return _context.Aderentes
                .Include(x => x.Empresa)
                .Where(AderenteSpacs.GetBy(empresaId, nome))
                .OrderBy(x => x.Id)
                .Skip(start * limit)
                .Take(limit)
                .ToList();
        }

    }
}
