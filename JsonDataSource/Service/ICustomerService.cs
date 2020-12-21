using JsonDataSource.Models;
using System;
using System.Collections.Generic;

namespace JsonDataSource.Service
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(Guid id);
        void AddCustomer(Customer customer);
    }
}