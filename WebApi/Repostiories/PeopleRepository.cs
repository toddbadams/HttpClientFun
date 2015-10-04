using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebApi.Models;

namespace WebApi.Repostiories
{
    public class PeopleRepository
    {
        private readonly List<Person> _people;
        private long _nextId;
        private readonly string _filename = @"c:\data.json";

        public PeopleRepository()
        {
            _people = JsonFileToList<Person>.Read(_filename) ?? Seed();
            _nextId = _people.Max(p => p.Id) + 1;
        }

        public Person Get(long id)
        {
            return _people
                .FirstOrDefault(p => p.Id == id);
        }

        public IList<Person> Fetch()
        {
            return _people;
        }

        public Person Update(long id, PersonUpdateOptions options)
        {
            var entity = _people
                .FirstOrDefault(p => p.Id == id);
            if (entity == null) return null;
            if (!string.IsNullOrEmpty(options.Last)) entity.Last = options.Last;
            if (!string.IsNullOrEmpty(options.First)) entity.First = options.First;
            JsonFileToList<Person>.Write(_filename, _people);
            return entity;
        }

        public Person Create(PersonAddOptions options)
        {
            var entity = new Person
            {
                Id = _nextId++,
                First = options.First,
                Last = options.Last
            };
            _people.Add(entity);
            JsonFileToList<Person>.Write(_filename, _people);
            return entity;
        }

        public void Delete(long id)
        {
            var entity = _people
                .FirstOrDefault(p => p.Id == id);
            if (entity != null)
                _people.Remove(entity);
            JsonFileToList<Person>.Write(_filename, _people);
        }

        private List<Person> Seed()
        {
            return new List<Person>
            {
                new Person
                {
                    Id = 1,
                    First = "Fred",
                    Last = "Flinsone"
                },
                new Person
                {
                    Id = 2,
                    First = "Wilma",
                    Last = "Flinsone"
                }
            };
        }

    }
}
