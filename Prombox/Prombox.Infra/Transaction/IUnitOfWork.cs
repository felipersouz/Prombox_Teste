using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Infra.Transaction
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
