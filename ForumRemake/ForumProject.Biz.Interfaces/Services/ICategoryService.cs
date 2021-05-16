using System.Threading.Tasks;

namespace ForumProject.Biz.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<string[]> GetAll();
    }
}
