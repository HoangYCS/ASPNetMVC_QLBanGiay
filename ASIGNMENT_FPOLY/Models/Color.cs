namespace ASIGNMENT_FPOLY.Models
{
    public class Color
    {

        public Guid Id { get; set; }

        public string NameColor { get; set; }
        public int Status { get; set; }

        public virtual IEnumerable<Product> Product { get; set; }
    }
}
