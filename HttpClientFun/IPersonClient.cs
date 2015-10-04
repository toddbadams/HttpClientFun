using System.Threading.Tasks;
using HttpClientFun.Models;

namespace HttpClientFun
{
    public interface IPersonClient
    {
        Task<Person> GetAsync(long id);
        Task<Person> PostAsync(PersonAddOptions options);
        Task<Person> PutAsync(long id, PersonUpdateOptions options);
        Task<Person> DeleteAsync(long id);
    }
}