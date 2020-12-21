using JsonDataSource.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using JsonDataSource.Helpers;
using JsonDataSource.Service;
using System.Linq;
using System;

namespace JsonDataSource.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            var customers = customerService.GetCustomers();

            if (customers.Count == 0)
            {
                customers = CustomerGenerator.GenerateCustomers();
            }

            return customers;
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(string id)
        {
            var customerId = Guid.Parse(id);
            var customer = customerService.GetCustomer(customerId);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        [HttpPost]
        public IActionResult Post()
        {
            var customer = CustomerGenerator.GenerateCustomers(1).First();

            customerService.AddCustomer(customer);

            return Ok();
        }
    }
}