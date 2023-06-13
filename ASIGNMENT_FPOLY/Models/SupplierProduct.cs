namespace ASIGNMENT_FPOLY.Models
{
    public class SupplierProduct
    {

        public Guid Id { get; set; }
        public Guid SupplierId { get; set; }

        public Guid ProductId { get; set; }


        public virtual Product Product { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
