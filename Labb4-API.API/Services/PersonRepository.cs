using Labb4_API.API.Models;
using Labb4_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_API.API.Services
{
    public class PersonRepository : ILabb4_API<Person>
    {
        private AppDbContext _appContext;
        public PersonRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public Person Add(Person newEntity)
        {
            var result = _appContext.Persons.Add(newEntity);
            _appContext.SaveChanges();
            return result.Entity;
        }

        public Person Delete(int id)
        {
            var result = _appContext.Persons.FirstOrDefault(p => p.PersonId == id);
            if (result != null)
            {
                _appContext.Persons.Remove(result);
                _appContext.SaveChanges();
                return result;
            }
            return null;
        }

        public IEnumerable<Person> GetAll()
        {
            return _appContext.Persons.ToList();
        }

        public Person GetSingle(int id)
        {
            return _appContext.Persons.FirstOrDefault(p => p.PersonId == id);        
        }

        public Person Update(Person entity)
        {
            var result = _appContext.Persons.FirstOrDefault(p => p.PersonId == entity.PersonId);

            if (result != null)
            {
                result.FirstName = entity.FirstName;
                result.LastName = entity.LastName;
                result.PhoneNr = entity.PhoneNr;
                _appContext.SaveChanges();
                return result;
            }
            return null;
        }
    }
}
