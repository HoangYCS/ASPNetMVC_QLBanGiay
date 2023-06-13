using ASIGNMENT_FPOLY.Models;

namespace ASIGNMENT_FPOLY.IServices
{
    public interface IProductService
    {

        public bool CreateProduct(Product obj);
        public bool ReStore(Product obj);
        public bool UpdateProduct(Product obj);
        public bool DeleteProduct(Guid id);
        public List<Product> GetAllProducts();
        public List<Product> GetAllProductsNoInclude();
        public List<Product> GetAllProductByAction(List<string> lstColor, List<string> lstSize, string searchKeyword, string sortBy);
        public Product GetProductById(Guid id);
        public List<Product> GetProductsByName(string name);
    }
}
