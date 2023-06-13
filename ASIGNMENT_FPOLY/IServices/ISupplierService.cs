using ASIGNMENT_FPOLY.Models;

namespace ASIGNMENT_FPOLY.IServices
{
    public interface ISupplierService
    {

        public bool CreateSupplier(Supplier obj);
        public bool UpdateSupplier(Supplier obj);
        public bool DeleteSupplier(Guid id);
        public List<Supplier> GetAllSuppliers();
        public Supplier GetSupplierById(Guid id);
        public List<Supplier> GetSuppliersByName(string name);
    }
}
