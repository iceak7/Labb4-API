using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_API.API.Services
{
    public interface ILabb4_API<T>
    {
        IEnumerable<T> GetAll();
        T GetSingle(int id);
        T Add(T newEntity);
        T Update(T entity);
        T Delete(int id);
    }
}
