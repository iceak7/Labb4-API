using Labb4_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_API.API.Services
{
    public interface ILinkRepository
    {
        IEnumerable<Link> GetAll();
        Link GetSingle(int id);
        Link Add(Link newEntity);
        Link Update(Link entity);
        Link Delete(int id);
        IEnumerable<Link> GetLinksByPerson(int id);
    }
}
