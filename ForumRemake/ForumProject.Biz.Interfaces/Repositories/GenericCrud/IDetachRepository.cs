using System.Threading.Tasks;

namespace ForumProject.Biz.Interfaces
{
    public interface IDetachRepository
    {
        Task DetachAllEntities();
    }
}