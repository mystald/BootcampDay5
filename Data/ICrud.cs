using System.Collections.Generic;
using System.Threading.Tasks;

namespace BootcampDay5.Data
{
    public interface ICrud<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetByName(string name);
        Task<T> Insert(T obj);
        Task<T> Update(int id, T obj);
        Task<T> Delete(int id);
    }
}
