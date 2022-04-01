using Prombox.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Infra.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // Não faz nada :)
        }
    }
}
