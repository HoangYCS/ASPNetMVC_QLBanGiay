using ASIGNMENT_FPOLY.IServices;
using ASIGNMENT_FPOLY.Models;
using Microsoft.EntityFrameworkCore;

namespace ASIGNMENT_FPOLY.Services
{
    public class BillService : IBillService
    {
        DBShopping context;
        public BillService()
        {
            context = new DBShopping();
        }
        public bool CreateBill(Bill p)
        {
            try
            {
                context.Bills.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteBill(Guid id)
        {
            try
            {
                var Bills = context.Bills.Find(id);
                context.Bills.Remove(Bills);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Bill> GetAllBills()
        {
            return context.Bills.Include("User").ToList();
        }
        public Bill GetBillById(Guid id)
        {
            return context.Bills.FirstOrDefault(p => p.Id == id);
        }
        public List<Bill> GetBillsByName(string name)
        {
            return context.Bills.Where(p => p.Note.ToString().Contains(name)).ToList();
        }
        public bool UpdateBill(Bill obj)
        {
            try
            {
                var Bill = context.Bills.Find(obj.Id);
                context.Bills.Update(Bill);
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
