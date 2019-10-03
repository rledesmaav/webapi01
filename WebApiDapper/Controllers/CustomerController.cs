using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DAL;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private CustomerRespository _ourCustomerRespository = new CustomerRespository();

        // GET: api/Customer
        [HttpGet]
        public List<Customer> Get()
        {
            return _ourCustomerRespository.GetCustomers(10, "ASC");
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public Customer Get(int id)
        {
            return _ourCustomerRespository.GetSingleCustomer(id);
        }

        // POST: api/Customer
        [HttpPost]
        public bool Post([FromBody]Customer ourCustomer)
        {
            return _ourCustomerRespository.InsertCustomer(ourCustomer);
        }

        // PUT: api/Customer/5
        [HttpPut]
        public bool Put([FromBody]Customer ourCustomer)
        {
            return _ourCustomerRespository.UpdateCustomer(ourCustomer);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name = "Delete")]
        public bool Delete(int id)
        {
            return _ourCustomerRespository.DeleteCustomer(id);
        }
    }
}
