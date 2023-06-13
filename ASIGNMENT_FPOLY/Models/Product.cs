
namespace ASIGNMENT_FPOLY.Models
{
    public class Product
    {

        public Guid Id { get; set; }

        public string ProductName { get; set; }
        public int Status { get; set; }

        public DateTime CreateDate { get; set; }
        public double Price { get; set; }

        public string Image { get; set; }
        public int AvailableQuality { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }

        public Guid BrandId { get; set; }

        public Guid ColorId { get; set; }

        public DateTime UpdateDate { get; set; }

        public Guid SizeId { get; set; }


        public virtual Category Category { get; set; }


        public virtual IEnumerable<SupplierProduct> SupplierProduct { get; set; }


        public virtual Color Color { get; set; }
        public virtual Size Size { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual IEnumerable<BillDetail> BillDetail { get; set; }

        public virtual IEnumerable<CartDetail> CartDetail { get; set; }
    }
}
