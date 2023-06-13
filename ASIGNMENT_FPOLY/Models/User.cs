namespace ASIGNMENT_FPOLY.Models
{
    public class User
    {

        public Guid IdUser { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public Guid RoleId { get; set; }
        public int Stustus { get; set; }


        public virtual IEnumerable<Bill> Bill { get; set; }

        public virtual Role Role { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
