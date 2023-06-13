namespace ASIGNMENT_FPOLY.Models
{
    public class Bill
    {

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime Creatdate { get; set; }

        public double TotalPrice { get; set; }

        public int Status { get; set; }

        public string shipping_address { get; set; }

        public string Note { get; set; }
        
        public virtual IEnumerable<BillDetail> BillDetail { get; set; }

        public virtual User User { get; set; }
    }
}
