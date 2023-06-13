using ASIGNMENT_FPOLY.Models;

namespace ASIGNMENT_FPOLY.IServices
{
    public interface ICartDetailService
    {

        public bool CreateCartDetail(CartDetail obj);
        public bool UpdateCartDetail(CartDetail obj);
        public bool DeleteCartDetail(Guid id);
        public List<CartDetail> GetAllCartDetails();
        public List<CartDetail> GetAllCartDetailByUserLogin(Guid id);
        public CartDetail GetCartDetailById(Guid id);
        public List<CartDetail> GetCartDetailsByName(string name);
    }
}
