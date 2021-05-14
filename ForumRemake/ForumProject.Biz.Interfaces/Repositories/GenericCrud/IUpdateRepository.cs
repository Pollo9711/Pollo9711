namespace ForumProject.Biz.Interfaces
{
    public interface IUpdateRepository<T>
    {
        void Update(T entity);
    }
}