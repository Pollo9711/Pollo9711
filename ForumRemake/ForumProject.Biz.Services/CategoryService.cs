using System;
using System.Threading.Tasks;
using ForumProject.Biz.Domain;
using ForumProject.Biz.Interfaces.Services;

namespace ForumProject.Biz.Services
{
    public class CategoryService : ICategoryService
    {
        public async Task<string[]> GetAll()
        {
            return await Task.Run(() => Enum.GetNames(typeof(CategoryEnum)));
        }
    }
}
