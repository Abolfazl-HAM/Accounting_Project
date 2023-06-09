﻿using Accounting.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Accounting.ViewModels.Customers;

namespace Accounting.DataLayer.Services
{
    public class CustomerRepository : ICustomerRepository
    {



        private Accounting_DBEntities db;
        public CustomerRepository(Accounting_DBEntities context)
        {
            db = context;
        }


        public IEnumerable<Customers> GetCustomersByFilter(string parameter)
        {
            return db.Customers.Where(c => c.FullName.Contains(parameter) || c.Mobile.Contains(parameter) || c.Email.Contains(parameter)).ToList();
        }

        public List<ListCustomerViwModel> GetNameCustomers(string filter = "")
        {
            if (filter == "")
            {
                return db.Customers.Select(f => new ListCustomerViwModel()
                {
                    CustomerID = f.CustomerID,
                    FullName = f.FullName
                }).ToList();
            }
            return db.Customers.Where(f => f.FullName.Contains(filter)).Select(f => new ListCustomerViwModel()
            {
                CustomerID = f.CustomerID,
                FullName = f.FullName
            }).ToList();
        }

        public string GetCustomerNameById(int customerId)
        {
            return db.Customers.Find(customerId).FullName;
        }

        public int GetCustomerIdByName(string name)
        {
            return db.Customers.First(c=> c.FullName == name).CustomerID;
        }

        public List<Customers> GetAllCustomers()
        {
            return db.Customers.ToList();
        }

        public Customers GetCustomerBayId(int customerId)
        {
            return db.Customers.Find(customerId);
        }

        public bool InsertCustomer(Customers customer)
        {
            try
            {
                db.Customers.Add(customer);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCustomer(Customers customer)
        {
            //try
            //{
            var local = db.Set<Customers>()
                         .Local
                         .FirstOrDefault(f => f.CustomerID == customer.CustomerID);
            if (local != null)
            {
                db.Entry(local).State = EntityState.Detached;
            }
            db.Entry(customer).State = EntityState.Modified;
            return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }

        public bool DeleteCustomer(Customers customer)
        {
            try
            {
                db.Entry(customer).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            try
            {
                var customer = GetCustomerBayId(customerId);
                DeleteCustomer(customer);
                return true;
            }
            catch
            {
                return false;
            }
        }

       
    }
}
