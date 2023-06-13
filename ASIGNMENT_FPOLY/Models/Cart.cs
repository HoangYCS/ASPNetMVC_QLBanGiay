namespace ASIGNMENT_FPOLY.Models
{
    public class Cart
    {

        public Guid UserId { get; set; }

        public string Descripttion { get; set; }

        public virtual IEnumerable<CartDetail> CartDetail { get; set; }

        public virtual User User { get; set; }

    }
}
