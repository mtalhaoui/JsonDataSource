using System;

namespace JsonDataSource.Models
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime Birthdate { get; private set; }
        public string Street { get; private set; }
        public int Number { get; private set; }
        public int ZipCode { get; private set; }
        public string City { get; private set; }

        public Customer(Guid id, string firstName, string lastName, DateTime birthdate, string street, int number, int zipCode, string city)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Street = street;
            Number = number;
            ZipCode = zipCode;
            City = city;
        }
    }
}