using System;
using System.Threading.Tasks;

namespace ForumProject.Biz.Interfaces
{
    public interface ICreateRepository<T>
    {
        Task Add(T element);
    }
}
