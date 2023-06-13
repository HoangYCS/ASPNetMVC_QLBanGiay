namespace ASIGNMENT_FPOLY.Models
{
    public class Brand
    {

        public Guid Id { get; set; }

        public string Name { get; set; }
        public int Status { get; set; }

        public virtual IEnumerable<Product> Product { get; set; }
    }
}
