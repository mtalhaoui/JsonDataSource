using JsonDataSource.Data;
using JsonDataSource.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JsonDataSource.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IDataContext<Customer> context;

        public CustomerService(IConfiguration configuration) => 
            context = new DataContext<Customer>(configuration.GetSection("DataContexts:Customer").Value);

        public List<Customer> GetCustomers() => context.Get().ToList();

        public Customer GetCustomer(Guid id) => context.Get().ToList().FirstOrDefault(x => x.Id == id);

        public void AddCustomer(Customer customer) => context.Add(customer);
    }
}