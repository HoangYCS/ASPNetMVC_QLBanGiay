using ASIGNMENT_FPOLY.IServices;
using ASIGNMENT_FPOLY.Models;
using Microsoft.EntityFrameworkCore;

namespace ASIGNMENT_FPOLY.Services
{
    public class CartDetailService : ICartDetailService
    {

        DBShopping context;
        public CartDetailService()
        {
            context = new DBShopping();
        }
        public bool CreateCartDetail(CartDetail p)
        {
            try
            {
                context.CartDetails.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCartDetail(Guid id)
        {
            try
            {
                var CartDetails = context.CartDetails.Find(id);
                context.CartDetails.Remove(CartDetails);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<CartDetail> GetAllCartDetailByUserLogin(Guid id)
        {
            if (GetAllCartDetails() == null) return new List<CartDetail>();
            return GetAllCartDetails().Where(x => x.UserId == id).ToList();
        }

        public List<CartDetail> GetAllCartDetails()
        {
            return context.CartDetails.Include(cd => cd.Product).ThenInclude(p => p.Color)
                .Include(cd => cd.Product).ThenInclude(p => p.Color)
                .Include(cd => cd.Product).ThenInclude(p => p.Size)
                .Include(cd => cd.Product).ThenInclude(p => p.Brand)
                .Include(cd => cd.Product).ThenInclude(p => p.Color)
                .ToList();
        }
        public CartDetail GetCartDetailById(Guid id)
        {
            return context.CartDetails.FirstOrDefault(p => p.Id == id);
        }
        public List<CartDetail> GetCartDetailsByName(string name)
        {
            return context.CartDetails.Where(p => p.Id.ToString().Contains(name)).ToList();
        }
        public bool UpdateCartDetail(CartDetail obj)
        {
            try
            {
                var CartDetail = context.CartDetails.Find(obj.Id);
                context.CartDetails.Update(CartDetail);
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
