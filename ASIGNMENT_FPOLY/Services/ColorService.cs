
using ASIGNMENT_FPOLY.IServices;
using ASIGNMENT_FPOLY.Models;

namespace ASIGNMENT_FPOLY.Services
{
    public class ColorService : IColorService
    {

        DBShopping context;
        public ColorService()
        {
            context = new DBShopping();
        }
        public bool CreateColor(Color p)
        {
            try
            {
                context.Colors.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteColor(Guid id)
        {
            try
            {
                var Colors = context.Colors.Find(id);
                context.Colors.Remove(Colors);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Color> GetAllColors()
        {
            return context.Colors.ToList();
        }
        public Color GetColorById(Guid id)
        {
            return context.Colors.FirstOrDefault(p => p.Id == id);
        }
        public List<Color> GetColorsByName(string name)
        {
            return context.Colors.Where(p => p.NameColor.Contains(name)).ToList();
        }
        public bool UpdateColor(Color obj)
        {
            try
            {
                var Color = context.Colors.Find(obj.Id);
                Color.NameColor = obj.NameColor;
                Color.Status = obj.Status;
                context.Colors.Update(Color);
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
