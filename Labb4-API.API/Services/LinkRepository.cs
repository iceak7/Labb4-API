using Labb4_API.API.Models;
using Labb4_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_API.API.Services
{
    public class LinkRepository : ILinkRepository
    {
        private AppDbContext _appContext;
        public LinkRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public Link Add(Link newEntity)
        {
            var result = _appContext.Links.Add(newEntity);
            _appContext.SaveChanges();
            return result.Entity;
        }

        public Link Delete(int id)
        {
            {
                var result = _appContext.Links.FirstOrDefault(l => l.LinkId == id);
                if (result != null)
                {
                    _appContext.Links.Remove(result);
                    _appContext.SaveChanges();
                    return result;
                }
                return null;
            }
        }
        public IEnumerable<Link> GetAll()
        {
            return _appContext.Links.ToList();
        }

        public IEnumerable<Link> GetLinksByPerson(int id)
        {
            var result = (from link in _appContext.Links
                          join hobby in _appContext.Hobbies
                          on link.HobbyId equals hobby.HobbyId
                          where hobby.PersonId == id
                          select link);

            if (result.Any())
            {
                return result.ToList();
            }
            return null;
        }

        public Link GetSingle(int id)
        {
            return _appContext.Links.FirstOrDefault(l=> l.LinkId == id);
        }

        public Link Update(Link entity)
        {
            var result = _appContext.Links.FirstOrDefault(l => l.LinkId == entity.LinkId);

            if (result != null)
            {
                result.URL = entity.URL;
                _appContext.SaveChanges();
                return result;
            }
            return null;
        }
    }
}
