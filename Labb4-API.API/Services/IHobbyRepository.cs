using Labb4_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_API.API.Services
{
    public interface IHobbyRepository
    {
        IEnumerable<Hobby> GetAll();
        Hobby GetSingle(int id);
        Hobby Add(Hobby newEntity);
        Hobby Update(Hobby entity);
        Hobby Delete(int id);
        IEnumerable<Hobby> GetHobbiesByPerson(int id);
    }
}
