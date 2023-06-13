using ASIGNMENT_FPOLY.IServices;
using ASIGNMENT_FPOLY.Models;

namespace ASIGNMENT_FPOLY.Services
{
    public class SizeService : ISizeService
    {

        DBShopping context;
        public SizeService()
        {
            context = new DBShopping();
        }
        public bool CreateSize(Size p)
        {
            try
            {
                context.Sizes.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteSize(Guid id)
        {
            try
            {
                var Sizes = context.Sizes.Find(id);
                context.Sizes.Remove(Sizes);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Size> GetAllSizes()
        {
            return context.Sizes.ToList();
        }
        public Size GetSizeById(Guid id)
        {
            return context.Sizes.FirstOrDefault(p => p.Id == id);
        }
        public Size GetSizesByName(string name)
        {
            return context.Sizes.FirstOrDefault(x => x.SizeName == name);
        }
        public bool UpdateSize(Size obj)
        {
            try
            {
                var Size = context.Sizes.Find(obj.Id);
                context.Sizes.Update(Size);
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
