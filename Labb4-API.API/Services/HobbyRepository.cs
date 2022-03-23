using Labb4_API.API.Models;
using Labb4_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_API.API.Services
{
    public class HobbyRepository : IHobbyRepository
    {
        private AppDbContext _appContext;
        public HobbyRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public Hobby Add(Hobby newEntity)
        {
            var result = _appContext.Hobbies.Add(newEntity);
            _appContext.SaveChanges();
            return result.Entity;
        }

        public Hobby Delete(int id)
        {
            var result = _appContext.Hobbies.FirstOrDefault(h => h.HobbyId == id);
            if (result != null)
            {
                _appContext.Hobbies.Remove(result);
                _appContext.SaveChanges();
                return result;
            }
            return null;
        }

        public IEnumerable<Hobby> GetAll()
        {
            return _appContext.Hobbies.ToList();
        }

        public IEnumerable<Hobby> GetHobbiesByPerson(int id)
        {
            var result = _appContext.Hobbies.Where(h => h.PersonId == id);

            if (result != null)
            {
                return result.ToList();
            }
            return null;
        }

        public Hobby GetSingle(int id)
        {
            return _appContext.Hobbies.FirstOrDefault(h => h.HobbyId == id);
        }

        public Hobby Update(Hobby entity)
        {
            var result = _appContext.Hobbies.FirstOrDefault(h => h.HobbyId == entity.HobbyId);

            if (result != null)
            {
                result.Description = entity.Description;
                result.Title = entity.Title;
                _appContext.SaveChanges();
                return result;
            }
            return null;
        }
    }
}
