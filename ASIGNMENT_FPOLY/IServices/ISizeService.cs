using ASIGNMENT_FPOLY.Models;

namespace ASIGNMENT_FPOLY.IServices
{
    public interface ISizeService
    {

        public bool CreateSize(Size obj);
        public bool UpdateSize(Size obj);
        public bool DeleteSize(Guid id);
        public List<Size> GetAllSizes();
        public Size GetSizeById(Guid id);
        public Size GetSizesByName(string name);
    }
}
