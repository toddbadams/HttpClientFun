using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Newtonsoft.Json;

namespace Client
{
    public class PersonClient
    {
        private const string BaseUrl = "http://localhost:9001/people";
        private readonly ClientFactory _clientFactory = new ClientFactory();

        public async Task<Person> GetAsync(long id)
        {
            using (var client = _clientFactory.Create())
            using (var response = await client.GetAsync(IdUrl(id)))
            using (var content = response.Content)
                return JsonConvert.DeserializeObject<Person>(await content.ReadAsStringAsync());
        }
        public async Task<IEnumerable<Person>> FetchAsync()
        {
            using (var client = _clientFactory.Create())
            using (var response = await client.GetAsync(BaseUrl))
            using (var content = response.Content)
                return JsonConvert.DeserializeObject<IEnumerable<Person>>(await content.ReadAsStringAsync());
        }

        public async Task<Person> CreateAsync(PersonAddOptions options)
        {
            using (var client = _clientFactory.Create())
            using (var response = client.PostAsync(BaseUrl, BuildJsonContent(options)).Result)
            using (var content = response.Content)
                return JsonConvert.DeserializeObject<Person>(await content.ReadAsStringAsync());
        }

        public async Task<Person> UpdateAsync(long id, PersonUpdateOptions options)
        {
            using (var client = _clientFactory.Create())
            using (var response = client.PutAsync(IdUrl(id), BuildJsonContent(options)).Result)
            using (var content = response.Content)
                return JsonConvert.DeserializeObject<Person>(await content.ReadAsStringAsync());
        }

        public async Task<Person> DeleteAsync(long id)
        {
            using (var client = _clientFactory.Create())
            using (var response = client.DeleteAsync(IdUrl(id)).Result)
            using (var content = response.Content)
                return JsonConvert.DeserializeObject<Person>(await content.ReadAsStringAsync());
        }

        private static StringContent BuildJsonContent(object obj)
        {
            return new StringContent(
                JsonConvert.SerializeObject(obj, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }),
                Encoding.UTF8,
                "application/json");
        }

        private static string IdUrl(long id)
        {
            return string.Format("{0}/{1}", BaseUrl, id);
        }
    }
}