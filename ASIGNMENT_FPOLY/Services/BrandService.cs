using ASIGNMENT_FPOLY.IServices;
using ASIGNMENT_FPOLY.Models;

namespace ASIGNMENT_FPOLY.Services
{
    public class BrandService : IBrandService
    {

        DBShopping context;
        public BrandService()
        {
            context = new DBShopping();
        }
        public bool CreateBrand(Brand p)
        {
            try
            {
                context.Brands.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteBrand(Guid id)
        {
            try
            {
                var Brands = context.Brands.Find(id);
                context.Brands.Remove(Brands);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Brand> GetAllBrands()
        {
            return context.Brands.ToList();
        }
        public Brand GetBrandById(Guid id)
        {
            return context.Brands.FirstOrDefault(p => p.Id == id);
        }
        public Brand GetBrandsByName(string name)
        {
            return context.Brands.FirstOrDefault(x=>x.Name==name);
        }
        public bool UpdateBrand(Brand obj)
        {
            try
            {
                var Brand = context.Brands.Find(obj.Id);
                Brand.Name = obj.Name;
                Brand.Status = obj.Status;
                context.Brands.Update(Brand);
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
