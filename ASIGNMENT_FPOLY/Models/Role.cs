namespace ASIGNMENT_FPOLY.Models
{
    public class Role
    { 
        public Guid Id { get; set; }

        public string RoleName { get; set; }

        public string Description { get; set; }
        public int Status { get; set; }

        public virtual IEnumerable<User> User { get; set; }
    }
}
