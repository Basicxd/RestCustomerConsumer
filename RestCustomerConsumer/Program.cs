using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        public static async Task<Customer> GetCustomersAsyncid(int id)
        {
            string CustomerUri = "https://localhost:44336/api/customer/" + id;
            using (HttpClient client = new HttpClient())
            {

                string content = await client.GetStringAsync(CustomerUri);
                Customer oneID = JsonConvert.DeserializeObject<Customer>(content);
                
                return oneID;


            }
        }

        public static async Task<HttpResponseMessage> GetCustomersAsyncDelete(int id)
        {
            string CustomerUri = "https://localhost:44336/api/customer/" + id;
            using (HttpClient client = new HttpClient())
            {
                var reponse = await client.DeleteAsync(CustomerUri);
                return reponse;
            }
        }

        public static async Task<HttpResponseMessage> GetCustomersAsyncAdd(string firstName, string lastName, int year)
        {
            string CustomerUri = "https://localhost:44336/api/customer/";
            using (HttpClient client = new HttpClient())
            {
                int lastId = GetCustomersAsync().Result.Last().ID;

                var jsonString = JsonConvert.SerializeObject(new Customer(firstName, lastName, year, lastId+1));


                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(CustomerUri, content);
                return response;



            }
        }




        static void Main(string[] args)
        {
            

            HttpResponseMessage adding = GetCustomersAsyncAdd("Mikol", "F", 1997).Result;

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

            //HttpResponseMessage adding = GetCustomersAsyncAdd("Mikol", "F", 1997).Result;
       

            //Customer result2 = GetCustomersAsyncid(0).Result;
            //Console.WriteLine(result2.ToString());

            //HttpResponseMessage delete = GetCustomersAsyncDelete(0).Result;

            //Console.WriteLine(result);



            Console.ReadLine();

        }
    }
}
