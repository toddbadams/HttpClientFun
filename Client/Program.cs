using System;
using System.Threading.Tasks;
using Client.Models;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();

            Console.WriteLine("Enter to quit. ");
            Console.ReadLine();
        }

        static async Task MainAsync()
        {
            var client = new PersonClient();
            await Fetch(client);
            var person = await Create(client);
            await Update(client, person.Id, new PersonUpdateOptions { First = "Betty" });
        }

        private static async Task Update(PersonClient client, long id, PersonUpdateOptions options)
        {
            Console.WriteLine("Update");
            var person = await client.UpdateAsync(id, options);
            Console.WriteLine(person.ToString());
        }

        private static async Task<Person> Create(PersonClient client)
        {
            Console.WriteLine("Create");
            var person = await client.CreateAsync(new PersonAddOptions
            {
                First = "Barney",
                Last = "Ruble"
            });
            Console.WriteLine(person.ToString());
            return person;
        }

        private static async Task Fetch(PersonClient client)
        {
            Console.WriteLine("Fetch");
            var persons = await client.FetchAsync();
            foreach (var person in persons)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
