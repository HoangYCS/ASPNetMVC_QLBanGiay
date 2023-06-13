using ASIGNMENT_FPOLY.Models;

namespace ASIGNMENT_FPOLY.IServices
{
    public interface IBrandService
    {

        public bool CreateBrand(Brand obj);
        public bool UpdateBrand(Brand obj);
        public bool DeleteBrand(Guid id);
        public List<Brand> GetAllBrands();
        public Brand GetBrandById(Guid id);
        public Brand GetBrandsByName(string name);
    }
}
