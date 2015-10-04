using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HttpClientFun.Models;
using Newtonsoft.Json;

namespace HttpClientFun
{
    public class PersonClient : IPersonClient
    {
        private const string BaseUrl = "http://localhost:123/person";

        public async Task<Person> GetAsync(long id)
        {
            using (var client = new HttpClient(new MessageHandler()))
            using (var response = await client.GetAsync(BaseUrl))
            using (var content = response.Content)
                return JsonConvert.DeserializeObject<Person>(await content.ReadAsStringAsync());
        }

        public async Task<Person> PostAsync(PersonAddOptions options)
        {
            using (var client = new HttpClient(new MessageHandler()))
            using (var response = client.PostAsync(BaseUrl, BuildJsonContent(options)).Result)
            using (var content = response.Content)
                return JsonConvert.DeserializeObject<Person>(await content.ReadAsStringAsync());
        }

        public async Task<Person> PutAsync(long id, PersonUpdateOptions options)
        {
            using (var client = new HttpClient(new MessageHandler()))
            using (var response = client.PutAsync(BaseUrl + "/" + id, BuildJsonContent(options)).Result)
            using (var content = response.Content)
                return JsonConvert.DeserializeObject<Person>(await content.ReadAsStringAsync());
        }

        public async Task<Person> DeleteAsync(long id)
        {
            using (var client = new HttpClient(new MessageHandler()))
            using (var response = client.DeleteAsync(BaseUrl + "/" + id).Result)
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
    }
}