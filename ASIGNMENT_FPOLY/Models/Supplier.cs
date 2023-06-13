namespace ASIGNMENT_FPOLY.Models
{
    public class Supplier
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        public int Phone { get; set; }

        public string Address { get; set; }


        public virtual IEnumerable<SupplierProduct> SupplierProduct { get; set; }

    }
}
