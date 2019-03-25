using System.Collections;
using System.Collections.Generic;

namespace RestCustomerConsumer
{
    public class Customer 
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Year { get; set; }

        public Customer(string firstName, string lastName, int year, int id = 0)
        {
            FirstName = firstName;
            LastName = lastName;
            Year = year;
            ID = id;
        }

        public override string ToString()
        {
            return $"{nameof(ID)}: {ID}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(Year)}: {Year}";
        }

        public Customer() { }

        
    }
}