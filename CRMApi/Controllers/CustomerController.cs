using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmApp;
using CrmApp.Options;
using CrmApp.Repository;
using CrmApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CRMApi.Controllers
{
    [ApiController]
    //controller=crm apo launchSettings
    [Route("[controller]")]

    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        //starting endpoint
        [HttpGet]
        public string Get()
        {

            return "Welcome to our site";
        }

        [HttpGet("all")]
        public List<Customer> getAllCustomer()
        {
            using CrmDbContext db = new CrmDbContext();
            CustomerManagement custMangr = new CustomerManagement(db);
            return db.Customers.ToList();
        }

        [HttpGet("{id}")]
        public Customer getCustomer(int id)
        {
            using CrmDbContext db = new CrmDbContext();
            CustomerManagement custMangr = new CustomerManagement(db);
            return custMangr.FindCustomerById(id);
        }

        [HttpPost("")]
        public Customer PostCustomer(CustomerOption custOpt)
        {
            using CrmDbContext db = new CrmDbContext();
            CustomerManagement custMangr = new CustomerManagement(db);
            return custMangr.CreateCustomer(custOpt);

        }
        [HttpGet("{id}")]
        public Customer Putcustomer(int id, CustomerOption custOpt)
        {
            using CrmDbContext db = new CrmDbContext();
            CustomerManagement custMangr = new CustomerManagement(db);
            return custMangr.Update(custOpt, id);
        }

        [HttpDelete("hard/{id}")]
        public bool HardDeleteCustomer(int id)
        {
            using CrmDbContext db = new CrmDbContext();
            CustomerManagement custMangr = new CustomerManagement(db);
            return custMangr.HardDeleteCustomerById(id);
        }
        [HttpPut("soft/{id}")]
        public bool SoftDeleteCustomer(int id)
        {
            using CrmDbContext db = new CrmDbContext();
            CustomerManagement custMangr = new CustomerManagement(db);
            return custMangr.SoftDeleteCustomerById(id);
        }
    }
}