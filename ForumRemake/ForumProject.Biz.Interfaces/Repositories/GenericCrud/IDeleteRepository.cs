namespace ForumProject.Biz.Interfaces
{
    public interface IDeleteRepository<T>
    {
        void Delete(T entity);
    }
}