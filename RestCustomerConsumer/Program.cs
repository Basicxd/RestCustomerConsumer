using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestCustomerConsumer
{
    public class Program
    {
      
        public static async Task<IList<Customer>> GetCustomersAsync()
        {
            string CustomerUri = "https://localhost:44336/api/customer";
            using (HttpClient client = new HttpClient())
            {
                
                string content = await client.GetStringAsync(CustomerUri);
                IList<Customer> cList = JsonConvert.DeserializeObject<IList<Customer>>(content);
                return cList;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IList<Customer> result = GetCustomersAsync().Result;
            Console.WriteLine(result.Count);
            foreach (Customer C in result)
            {
                int ID = C.ID;
                string firstName = C.FirstName;
                string lastName = C.LastName;
                int year = C.Year;
                Console.WriteLine($"Id: {ID} First Name: {firstName} Last Name: {lastName} Year: {year}");


            }

            Console.ReadLine();

        }
    }
}
