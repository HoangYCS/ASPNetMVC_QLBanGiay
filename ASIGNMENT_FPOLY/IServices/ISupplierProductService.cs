using ASIGNMENT_FPOLY.Models;

namespace ASIGNMENT_FPOLY.IServices
{
    public interface ISupplierProductService
    {

        public bool CreateSupplierProduct(SupplierProduct obj);
        public bool UpdateSupplierProduct(SupplierProduct obj);
        public bool DeleteSupplierProduct(Guid id);
        public List<SupplierProduct> GetAllSupplierProducts();
        public SupplierProduct GetSupplierProductById(Guid id);
        public List<SupplierProduct> GetSupplierProductsByName(string name);
    }
}
