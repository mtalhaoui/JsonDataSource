using Bogus;
using JsonDataSource.Models;
using System;
using System.Collections.Generic;

namespace JsonDataSource.Helpers
{
    public static class CustomerGenerator
    {
        private static readonly Random random = new Random();
        private static readonly Faker faker = new Faker();

        public static List<Customer> GenerateCustomers(int numberOfCustomers = 5)
        {
            var customers = new List<Customer>();

            for (int i = 0; i < numberOfCustomers; i++)
            {
                var lastName = faker.Name.LastName();
                var firstName = faker.Name.FirstName();
                var street = faker.Address.StreetName();
                var number = random.Next(1, 500);
                var zipCode = random.Next(1000, 9999);
                var city = faker.Address.City();
                var birthDate = faker.Date.Between(new DateTime(1970, 1, 1), DateTime.Now.AddYears(-15));
                var driver = new Customer(Guid.NewGuid(), lastName, firstName, birthDate, street, number, zipCode, city);
                customers.Add(driver);
            }

            return customers;
        }
    }
}