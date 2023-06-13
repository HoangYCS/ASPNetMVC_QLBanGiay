using ASIGNMENT_FPOLY.Models;

namespace ASIGNMENT_FPOLY.IServices
{
    public interface IRoleService
    {

        public bool CreateRole(Role obj);
        public bool UpdateRole(Role obj);
        public bool DeleteRole(Guid id);
        public List<Role> GetAllRoles();
        public Role GetRoleById(Guid id);
        public List<Role> GetRolesByName(string name);
    }
}
