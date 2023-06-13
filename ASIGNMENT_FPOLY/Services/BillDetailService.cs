using ASIGNMENT_FPOLY.IServices;
using ASIGNMENT_FPOLY.Models;
using Microsoft.EntityFrameworkCore;

namespace ASIGNMENT_FPOLY.Services
{
    public class BillDetailService : IBillDetaiService
    {

        DBShopping context;
        public BillDetailService()
        {
            context = new DBShopping();
        }
        public bool CreateBillDetail(BillDetail p)
        {
            try
            {
                context.BillDetails.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteBillDetail(Guid id)
        {
            try
            {
                var BillDetails = context.BillDetails.Find(id);
                context.BillDetails.Remove(BillDetails);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<BillDetail> GetAllBillDetails()
        {
            return context.BillDetails.Include("Product").ToList();
        }
        public BillDetail GetBillDetailById(Guid id)
        {
            return context.BillDetails.FirstOrDefault(p => p.Id == id);
        }
        public List<BillDetail> GetBillDetailsByName(string name)
        {
            return context.BillDetails.Where(p => p.Price.ToString().Contains(name)).ToList();
        }
        public bool UpdateBillDetail(BillDetail obj)
        {
            try
            {
                var BillDetail = context.BillDetails.Find(obj.Id);
                context.BillDetails.Update(BillDetail);
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
