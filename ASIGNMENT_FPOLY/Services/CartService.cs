using ASIGNMENT_FPOLY.IServices;
using ASIGNMENT_FPOLY.Models;

namespace ASIGNMENT_FPOLY.Services
{
    public class CartService : ICartService
    {

        DBShopping context;
        public CartService()
        {
            context = new DBShopping();
        }
        public bool CreateCart(Cart p)
        {
            try
            {
                context.Carts.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCart(Guid id)
        {
            try
            {
                var Carts = context.Carts.Find(id);
                context.Carts.Remove(Carts);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Cart> GetAllCarts()
        {
            return context.Carts.ToList();
        }

        public Cart GetCartById(Guid id)
        {
            return context.Carts.FirstOrDefault(p => p.UserId == id);
        }
        public List<Cart> GetCartsByName(string name)
        {
            return context.Carts.Where(p => p.Descripttion.Contains(name)).ToList();
        }
        public bool UpdateCart(Cart obj)
        {
            try
            {
                var Cart = context.Carts.Find(obj.UserId);
                Cart.Descripttion = obj.Descripttion;
                context.Carts.Update(Cart);
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
