using ASIGNMENT_FPOLY.IServices;
using ASIGNMENT_FPOLY.Models;

namespace ASIGNMENT_FPOLY.Services
{
    public class CategoryService : ICategoryService
    {

        DBShopping context;
        public CategoryService()
        {
            context = new DBShopping();
        }
        public bool CreateCategory(Category p)
        {
            try
            {
                context.Categorys.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCategory(Guid id)
        {
            try
            {
                var Categorys = context.Categorys.Find(id);
                context.Categorys.Remove(Categorys);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Category> GetAllCategorys()
        {
            return context.Categorys.ToList();
        }
        public Category GetCategoryById(Guid id)
        {
            return context.Categorys.FirstOrDefault(p => p.Id == id);
        }
        public Category GetCategorysByName(string name)
        {
            return context.Categorys.FirstOrDefault(x=>x.Name==name);
        }
        public bool UpdateCategory(Category obj)
        {
            try
            {
                var Category = context.Categorys.Find(obj.Id);
                Category.Name = obj.Name;
                Category.Title= obj.Title;
                Category.Status= obj.Status;
                context.Categorys.Update(Category);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
