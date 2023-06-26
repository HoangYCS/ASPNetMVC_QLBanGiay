
namespace ASIGNMENT_FPOLY.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public string ProductName { get; set; }

        public double Price { get; set; }

        public string NameBrand { get; set; }

        public string NameCategory { get; set; }

        public Guid SizeId { get; set; }

        public Guid ColorId { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int AvailableQuality { get; set; }
        public Guid CategoryId { get; set; }

        public Guid BrandId { get; set; }

        public List<CheckViewModel> ListSelect { get; set; }

    }
}
