using ASIGNMENT_FPOLY.IServices;
using ASIGNMENT_FPOLY.Models;

namespace ASIGNMENT_FPOLY.Services
{
    public class SupplierProductService : ISupplierProductService
    {

        DBShopping context;
        public SupplierProductService()
        {
            context = new DBShopping();
        }
        public bool CreateSupplierProduct(SupplierProduct p)
        {
            try
            {
                context.SupplierProducts.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteSupplierProduct(Guid id)
        {
            try
            {
                var SupplierProducts = context.SupplierProducts.Find(id);
                context.SupplierProducts.Remove(SupplierProducts);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<SupplierProduct> GetAllSupplierProducts()
        {
            return context.SupplierProducts.ToList();
        }
        public SupplierProduct GetSupplierProductById(Guid id)
        {
            return context.SupplierProducts.FirstOrDefault(p => p.Id == id);
        }
        public List<SupplierProduct> GetSupplierProductsByName(string name)
        {
            return context.SupplierProducts.Where(p => p.ProductId.ToString().Contains(name)).ToList();
        }
        public bool UpdateSupplierProduct(SupplierProduct obj)
        {
            try
            {
                var SupplierProduct = context.SupplierProducts.Find(obj.Id);
                context.SupplierProducts.Update(SupplierProduct);
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
