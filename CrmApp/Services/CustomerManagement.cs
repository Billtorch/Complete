using CrmApp.Options;
using CrmApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrmApp.Services
{
    public class CustomerManagement
    {
        private CrmDbContext db;

        public CustomerManagement(CrmDbContext _db)
        {
            db = _db;
        }


        //CRUD
        // create read update delete
        public Customer CreateCustomer(CustomerOption custOption)
        {
            Customer customer = new Customer
            {
                FirstName = custOption.FirstName,
                LastName = custOption.LastName,
                Address = custOption.Address,
                Dob = custOption.Dob,
                Email = custOption.Email,
                Active = true,
                Balance = 0,
            };


            db.Customers.Add(customer);
            db.SaveChanges();

            return customer;
        }

        public Customer FindCustomerById(int customerId)
        {

            return db.Customers.Find(customerId);
        }

        public List<Customer> FindCustomerByName(CustomerOption custOption)
        {
            return db.Customers
                .Where(cust => cust.LastName == custOption.LastName)
                .Where(cust => cust.FirstName == custOption.FirstName)
                .ToList();
        }


        public Customer Update(CustomerOption custOption, int customerId)
        {

            Customer customer = db.Customers.Find(customerId);

            if (custOption.FirstName != null)
                customer.FirstName = custOption.FirstName;
            if (custOption.LastName != null)
                customer.LastName = custOption.LastName;
            if (custOption.Email != null)
                customer.Email = custOption.Email;
            if (custOption.Address != null)
                customer.Address = custOption.Address;

            db.SaveChanges();
            return customer;
        }

        public bool HardDeleteCustomerById(int id)
        {

            Customer customer = db.Customers.Find(id);
            if (customer != null)
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        
        public bool SoftDeleteCustomerById(int id)
        {

            Customer customer = db.Customers.Find(id);
            if (customer != null)
            {
                customer.Active = false;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Customer> GetAllCustomers(CustomerOption custOpt)
        {
            return db.Customers
                .ToList();
        }
    } 
    }


