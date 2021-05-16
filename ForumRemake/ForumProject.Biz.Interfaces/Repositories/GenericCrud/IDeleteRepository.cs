using System.Threading.Tasks;

namespace ForumProject.Biz.Interfaces
{
    public interface IDeleteRepository<T>
    {
        Task Delete(T entity);
    }
}