using Accounting.DataLayer.Repositories;
using Accounting.DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Accounting.DataLayer.Context
{
    public class UnitOfWork : IDisposable
    {
        Accounting_DBEntities db = new Accounting_DBEntities();

        private ICustomerRepository _customerRepository;

        private GenericRepository<Accounting> _accountingRepository;

        private GenericRepository<Login> _loginRepository;



        public ICustomerRepository CustomerRepository
        {
            get
            {
                if( _customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(db);
                }
                return _customerRepository;
            }
        }

        public GenericRepository<Accounting> AccountingRepository 
        { 
            get
            {
                if (_accountingRepository == null)
                {
                    _accountingRepository = new GenericRepository<Accounting>(db);
                }
                return _accountingRepository;
            }
        }

        public GenericRepository<Login> LoginRepository
        {
            get
            {
                if (_loginRepository == null)
                {
                    return _loginRepository = new GenericRepository<Login>(db);
                }

                return _loginRepository;
            }
            }
            
        



        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
