using Prombox.Infra.Transaction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Service.Services
{
    public class BaseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Commit()
        {
            _unitOfWork.Commit();
            return true;
        }

        public void Rollback(string message)
        {
            _unitOfWork.Rollback();
        }

        public void Rollback()
        {
            _unitOfWork.Rollback();
        }
    }
}
