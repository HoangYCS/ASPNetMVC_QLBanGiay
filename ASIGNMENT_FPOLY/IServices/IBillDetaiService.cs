using ASIGNMENT_FPOLY.Models;

namespace ASIGNMENT_FPOLY.IServices
{
    public interface IBillDetaiService
    {

        public bool CreateBillDetail(BillDetail obj);
        public bool UpdateBillDetail(BillDetail obj);
        public bool DeleteBillDetail(Guid id);
        public List<BillDetail> GetAllBillDetails();
        public BillDetail GetBillDetailById(Guid id);
        public List<BillDetail> GetBillDetailsByName(string name);
    }
}
