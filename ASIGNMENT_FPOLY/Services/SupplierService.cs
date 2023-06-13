using ASIGNMENT_FPOLY.IServices;
using ASIGNMENT_FPOLY.Models;

namespace ASIGNMENT_FPOLY.Services
{
    public class SupplierService : ISupplierService
    {

        DBShopping context;
        public SupplierService()
        {
            context = new DBShopping();
        }
        public bool CreateSupplier(Supplier p)
        {
            try
            {
                context.Suppliers.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteSupplier(Guid id)
        {
            try
            {
                var Suppliers = context.Suppliers.Find(id);
                context.Suppliers.Remove(Suppliers);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Supplier> GetAllSuppliers()
        {
            return context.Suppliers.ToList();
        }
        public Supplier GetSupplierById(Guid id)
        {
            return context.Suppliers.FirstOrDefault(p => p.Id == id);
        }
        public List<Supplier> GetSuppliersByName(string name)
        {
            return context.Suppliers.Where(p => p.Name.Contains(name)).ToList();
        }
        public bool UpdateSupplier(Supplier obj)
        {
            try
            {
                var Supplier = context.Suppliers.Find(obj.Id);
                context.Suppliers.Update(Supplier);
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
