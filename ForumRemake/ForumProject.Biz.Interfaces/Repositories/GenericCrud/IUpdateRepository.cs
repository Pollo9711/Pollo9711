using System.Threading.Tasks;

namespace ForumProject.Biz.Interfaces
{
    public interface IUpdateRepository<T>
    {
        Task Update(T entity);
    }
}