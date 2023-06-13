namespace ASIGNMENT_FPOLY.Models
{
    public class Size
    {

        public Guid Id { get; set; }

        public string SizeName { get; set; }
        public int Status { get; set; }


        public virtual IEnumerable<Product> Product { get; set; }
    }
}
