using ASIGNMENT_FPOLY.Models;

namespace ASIGNMENT_FPOLY.IServices
{
    public interface IBillService
    {

        public bool CreateBill(Bill obj);
        public bool UpdateBill(Bill obj);
        public bool DeleteBill(Guid id);
        public List<Bill> GetAllBills();
        public Bill GetBillById(Guid id);
        public List<Bill> GetBillsByName(string name);
    }
}
