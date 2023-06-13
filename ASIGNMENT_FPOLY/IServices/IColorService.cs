

using ASIGNMENT_FPOLY.Models;

namespace ASIGNMENT_FPOLY.IServices
{
    public interface IColorService
    {

        public bool CreateColor(Color obj);
        public bool UpdateColor(Color obj);
        public bool DeleteColor(Guid id);
        public List<Color> GetAllColors();
        public Color GetColorById(Guid id);
        public List<Color> GetColorsByName(string name);
    }
}
