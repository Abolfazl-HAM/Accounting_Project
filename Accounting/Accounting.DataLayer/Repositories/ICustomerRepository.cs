using Accounting.ViewModels.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customers> GetCustomersByFilter(string parameter);

        List<ListCustomerViwModel> GetNameCustomers(string filter = "");

        int GetCustomerIdByName(string name);

        List<Customers> GetAllCustomers();
        
        Customers GetCustomerBayId(int customerId);
        
        bool InsertCustomer(Customers customer);
        
        bool UpdateCustomer(Customers customer);
        
        bool DeleteCustomer(Customers customer);
        
        bool DeleteCustomer(int customerId);
       

        
    }
}
