using System.Web.Http;
using WebApi.Models;
using WebApi.Repostiories;

namespace WebApi.Controllers
{
    public class PeopleController : ApiController
    {
        private readonly PeopleRepository _peopleRepository = new PeopleRepository();

        [HttpGet]
        [Route("people/{id:long}", Name = "getPerson")]
        public IHttpActionResult Get(long id)
        {
            var vm = _peopleRepository.Get(id);
            return Ok(vm);
        }

        [HttpGet]
        [Route("people", Name = "getAllPeople")]
        public IHttpActionResult Fetch()
        {
            var vm = _peopleRepository.Fetch();
            return Ok(vm);
        }

        [HttpPost]
        [Route("people", Name = "addPerson")]
        public IHttpActionResult Post(PersonAddOptions options)
        {
            var vm = _peopleRepository.Create(options);
            return Ok(vm);
        }

        [HttpPut]
        [Route("people/{id:long}", Name = "updatePerson")]
        public IHttpActionResult Put(long id, PersonUpdateOptions options)
        {
            var vm = _peopleRepository.Update(id, options);
            return Ok(vm);
        }

        [HttpDelete]
        [Route("people/{id:long}", Name = "deletePerson")]
        public IHttpActionResult Delete(long id)
        {
            _peopleRepository.Delete(id);
            return Ok();
        }

    }
}
