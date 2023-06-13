namespace ASIGNMENT_FPOLY.Models
{
    public class BillDetail
    {

        public Guid Id { get; set; }

        public Guid BillId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantily { get; set; }

        public double Price { get; set; }

        public virtual Bill Bill { get; set; }

        public virtual Product Product { get; set; }
    }
}
