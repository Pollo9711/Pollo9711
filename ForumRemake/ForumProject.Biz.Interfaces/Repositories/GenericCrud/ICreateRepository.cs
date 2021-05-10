using System;

namespace ForumProject.Biz.Interfaces
{
    public interface ICreateRepository<T>
    {
        void Add(T element);
    }
}
