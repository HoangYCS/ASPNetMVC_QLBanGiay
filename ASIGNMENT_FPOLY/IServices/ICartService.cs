using ASIGNMENT_FPOLY.Models;

namespace ASIGNMENT_FPOLY.IServices
{
    public interface ICartService
    {

        public bool CreateCart(Cart obj);
        public bool UpdateCart(Cart obj);
        public bool DeleteCart(Guid id);
        public List<Cart> GetAllCarts();
        public Cart GetCartById(Guid id);
        public List<Cart> GetCartsByName(string name);
    }
}
