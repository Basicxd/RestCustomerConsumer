namespace RestCustomerConsumer
{
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Year { get; set; }

        public Customer(string firstName, string lastName, int year)
        {
            FirstName = firstName;
            LastName = lastName;
            Year = year;
        }

        public Customer() { }
    }
}