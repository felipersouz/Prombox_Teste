using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Infra.Repositories
{
    public class BaseRepository
    {
        protected DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }
    }
}
