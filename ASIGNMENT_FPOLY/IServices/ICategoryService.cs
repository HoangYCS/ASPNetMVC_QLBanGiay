using ASIGNMENT_FPOLY.Models;

namespace ASIGNMENT_FPOLY.IServices
{
    public interface ICategoryService
    {

        public bool CreateCategory(Category obj);
        public bool UpdateCategory(Category obj);
        public bool DeleteCategory(Guid id);
        public List<Category> GetAllCategorys();
        public Category GetCategoryById(Guid id);
        public Category GetCategorysByName(string name);
    }
}
