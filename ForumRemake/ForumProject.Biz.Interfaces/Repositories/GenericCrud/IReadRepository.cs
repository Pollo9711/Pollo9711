using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumProject.Biz.Interfaces
{
    public interface IReadRepository<T, TKey>
    {
        Task<List<T>> GetAll();

        Task<T> GetById(TKey id);
    }
}