using System.Collections.Generic;

namespace ForumProject.Biz.Interfaces
{
    public interface IReadRepository<T, TKey>
    {
        List<T> GetAll();

        T GetById(TKey id);
    }
}